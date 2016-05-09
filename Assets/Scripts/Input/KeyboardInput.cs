using UnityEngine;
using System.Collections;

public class KeyboardInput : MonoBehaviour {

    PlayerMovement pm;

    bool forward, backward, jump, suicide;

    void Start() {
        pm = GetComponent<PlayerMovement>();
    }

	void FixedUpdate () {
        UpdateBools();
        ProcessAndSendMovement();
	}

    void UpdateBools() {
        forward = backward = jump = suicide = false;

        forward = Input.GetKey(KeyCode.D);
        backward = Input.GetKey(KeyCode.A);
        jump = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W);

        suicide = Input.GetKeyDown(KeyCode.P);
    }

    void ProcessAndSendMovement() {
        pm.Move(forward, backward, jump, suicide);
    }
}
