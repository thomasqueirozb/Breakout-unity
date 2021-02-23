using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    [Range(1, 15)]
    public float speed = 5.0f;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start() {
        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(1.0f, 5.0f);

        direction = new Vector3(dirX, dirY).normalized;
    }

    // Update is called once per frame
    void Update() {
        transform.position += direction * speed * Time.deltaTime;
        Vector2 positionViewport = Camera.main.WorldToViewportPoint(transform.position);

        if (positionViewport.x < 0 || positionViewport.x > 1) {
            direction = new Vector3(-direction.x, direction.y);
        }

        if (positionViewport.y < 0 || positionViewport.y > 1) {
            direction = new Vector3(direction.x, -direction.y);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {
            float dirX = Random.Range(-5.0f, 5.0f);
            float dirY = Random.Range(1.0f, 5.0f);

            direction = new Vector3(dirX, dirY).normalized;
        } else if (col.gameObject.CompareTag("Brick")) {
            direction = new Vector3(direction.x, -direction.y);
        }

    }


}
