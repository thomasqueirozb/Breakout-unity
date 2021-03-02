using UnityEngine;

public class BallMovement : MonoBehaviour {
    [Range(1, 15)]
    public float speed = 5.0f;

    private Vector3 direction;

    GameManager gm;

    void Start() {
        gm = GameManager.GetInstance();

        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(1.0f, 5.0f);

        direction = new Vector3(dirX, dirY).normalized;
        GameManager.newGameDelegate += ResetInitial;

    }

    void ResetInitial() {
        transform.position = new Vector3(0.0f, -3.5f, 0.0f);
    }

    void Update() {
        if (gm.gameState != GameManager.GameState.GAME)
            return;


        transform.position += direction * speed * Time.deltaTime;
        Vector2 positionViewport = Camera.main.WorldToViewportPoint(transform.position);

        if (positionViewport.x < 0 || positionViewport.x > 1) {
            direction = new Vector3(-direction.x, direction.y);
        }

        if (positionViewport.y < 0 || positionViewport.y > 1) {
            direction = new Vector3(direction.x, -direction.y);
        }

        if (positionViewport.y < 0) {
            Reset();
        }
    }

    private void Reset() {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = playerPosition + new Vector3(0, 0.5f, 0);

        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(2.0f, 5.0f);

        direction = new Vector3(dirX, dirY).normalized;
        gm.lifes--;

        if (gm.lifes <= 0 && gm.gameState == GameManager.GameState.GAME) {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {
            float dirX = Random.Range(-5.0f, 5.0f);
            float dirY = Random.Range(1.0f, 5.0f);

            direction = new Vector3(dirX, dirY).normalized;
        } else if (col.gameObject.CompareTag("Brick")) {
            direction = new Vector3(direction.x, -direction.y);
            gm.points += 10;
        }

    }


}
