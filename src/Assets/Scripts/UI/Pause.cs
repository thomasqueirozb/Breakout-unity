using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    GameManager gm;
    private void OnEnable() {
        gm = GameManager.GetInstance();
    }

    public void Continue() {
        gm.ChangeState(GameManager.GameState.GAME);
    }

    public void GiveUp() {
        gm.ChangeState(GameManager.GameState.MENU);
    }
}
