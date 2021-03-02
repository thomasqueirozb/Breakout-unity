using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {
    public enum GameState { MENU, GAME, PAUSE, ENDGAME };

    public GameState gameState { get; private set; }
    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    private static GameManager instance;

    // Game elements
    public int lifes;
    public int points;


    private GameManager() {
        lifes = 3;
        points = 0;
        gameState = GameState.MENU;
    }

    public static GameManager GetInstance() {
        if (instance == null)
            instance = new GameManager();

        return instance;
    }


    public void ChangeState(GameState nextState) {
        if (nextState == GameState.GAME)
            Reset();
        gameState = nextState;
        changeStateDelegate();
    }

    private void Reset() {
        lifes = 3;
        points = 0;
    }
}
