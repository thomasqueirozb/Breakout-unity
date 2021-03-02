using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {
    public GameObject Points;
    Text textPoints;

    public GameObject Lifes;
    Text textLifes;

    GameManager gm;

    void Start() {
        textPoints = Points.GetComponent<Text>();
        textLifes = Lifes.GetComponent<Text>();
        gm = GameManager.GetInstance();

        textPoints.text = $"Pontos: {gm.points}";
        textLifes.text = $"Vidas: {gm.lifes}";

    }

    void Update() {
        textPoints.text = $"Pontos: {gm.points}";
        textLifes.text = $"Vidas: {gm.lifes}";
    }
}