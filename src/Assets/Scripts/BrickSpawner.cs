using UnityEngine;

public class BrickSpawner : MonoBehaviour {
    public GameObject Brick;
    GameManager gm;

    void Construct() {
        if (gm.gameState == GameManager.GameState.GAME) {
            foreach (Transform child in transform) {
                GameObject.Destroy(child.gameObject);
            }

            for (int i = 0; i < 12; i++) {
                for (int j = 0; j < 4; j++) {
                    Vector3 pos = new Vector3(-9 + 1.55f * i, 4 - 0.55f * j);
                    GameObject b = Instantiate(Brick, pos, Quaternion.identity, transform);
                    b.GetComponent<Brick>().setDurability(j + 1);
                }
            }
        }
    }

    void Start() {
        gm = GameManager.GetInstance();
        GameManager.newGameDelegate += Construct;
        Construct();
    }

    void Update() {
        if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME) {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }


    }
}
