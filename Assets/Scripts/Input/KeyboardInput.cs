using UnityEngine;

public class KeyboardInput : MonoBehaviour {

    PlayerMovement pm;
    PauseMenu psm;

    bool forward, backward, jump, suicide, escape;

    void Start() {
        pm = GetComponent<PlayerMovement>();
        psm = GetComponent<PauseMenu>();
    }

	void FixedUpdate () {
        UpdateBools();
        ProcessAndSendMovement();
	}

    void UpdateBools() {
        forward = backward = jump = suicide = escape = false;

        forward = Input.GetKey(KeyCode.D);
        backward = Input.GetKey(KeyCode.A);
        jump = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W);
        escape = Input.GetKeyDown(KeyCode.KeypadEnter);
        suicide = Input.GetKeyDown(KeyCode.P);
    }

    void ProcessAndSendMovement() {
        pm.Move(forward, backward, jump, suicide);
        psm.PauseGame(escape);
    }
}
