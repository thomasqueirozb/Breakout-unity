﻿using System.Collections;
using System.Collections.Generic;
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
                    Instantiate(Brick, pos, Quaternion.identity, transform);
                }
            }
        }
    }

    void Start() {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Construct;
        Construct();


    }

    void Update() {
        if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME) {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }


    }
}
