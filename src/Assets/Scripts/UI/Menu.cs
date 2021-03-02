using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    GameManager gm;

    private void OnEnable() {
        gm = GameManager.GetInstance();
    }

    public void Init() {
        gm.ChangeState(GameManager.GameState.GAME);
    }

}
