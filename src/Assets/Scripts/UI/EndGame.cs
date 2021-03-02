using UnityEngine;
using UnityEngine.UI;
public class EndGame : MonoBehaviour {
    public Text message;

    GameManager gm;
    private void OnEnable() {
        gm = GameManager.GetInstance();

        if (gm.lifes > 0) {
            message.text = "Você Ganhou :)";
        } else {
            message.text = "Você Perdeu :(";
        }
    }
    public void GoBack() {
        gm.ChangeState(GameManager.GameState.GAME);
    }
}