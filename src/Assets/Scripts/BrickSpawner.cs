﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour {
    public GameObject Brick;
    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < 12; i++) {
            for (int j = 0; j < 4; j++) {
                Vector3 pos = new Vector3(-9 + 1.55f * i, 4 - 0.55f * j);
                Instantiate(Brick, pos, Quaternion.identity, transform);
            }
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
