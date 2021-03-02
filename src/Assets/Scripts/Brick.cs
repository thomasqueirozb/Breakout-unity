using UnityEngine;

public class Brick : MonoBehaviour {
    static Color[] colors = {
        new Color32(59, 226, 229, 255),
        new Color32(59, 121, 229, 255),
        new Color32(94, 6, 137, 255),
        new Color32(57, 5, 84, 255)
    };

    private Renderer r;
    private int durability;

    private void OnTriggerEnter2D(Collider2D _collider) {
        durability--;
        if (durability == 0) {
            Destroy(gameObject);
        } else {
            setColor(durability - 1);
        }
    }

    void setColor(int i) {
        GetComponent<Renderer>().material.SetColor("_Color", colors[i]);
    }

    public void setDurability(int d) {
        durability = d;
        setColor(d - 1);
    }

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }
}
