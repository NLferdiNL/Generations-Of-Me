using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour {

    Respawner resp;
    Text label;

    void Start() {
        // I really just like to put things in the camera cause it's so easy to access
        // without too much work.
        resp = Camera.main.GetComponent<Respawner>();
        label = GetComponent<Text>();
    }

    void Update() {
        label.text = resp.Lives + " of " + resp.MaxLives + " left";
    }
}
