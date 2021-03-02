using UnityEngine;

public class PaddleMovement : MonoBehaviour {
    [Range(1, 50)]
    public float speed = 20.0f;
    GameManager gm;

    // Start is called before the first frame update
    void Start() {
        gm = GameManager.GetInstance();
        GameManager.newGameDelegate += Reset;
    }

    void Reset() {
        transform.position = new Vector3(0, -4, 0);
    }

    // Update is called once per frame
    void Update() {
        if (gm.gameState != GameManager.GameState.GAME)
            return;


        float inputX = Input.GetAxis("Horizontal");

        bool inputL = Input.GetKey("left");
        bool inputD = Input.GetKey("d");
        bool inputR = Input.GetKey("right");
        bool inputA = Input.GetKey("a");

        int right = (inputR | inputD) ? 1 : 0;
        int left = (inputL | inputA) ? 1 : 0;

        transform.position += new Vector3(right - left, 0, 0) * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME)
            gm.ChangeState(GameManager.GameState.PAUSE);

    }
}
