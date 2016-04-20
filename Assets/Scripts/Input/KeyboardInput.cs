using UnityEngine;
using System.Collections;
using KC = KeyboardConfig;

public class KeyboardInput : MonoBehaviour {

    PlayerMovement pm;

    bool forward, backward, jump, crouch, use;

    void Start() {
        pm = GetComponent<PlayerMovement>();
    }

	void FixedUpdate () {
        UpdateBools();
        ProcessAndSendMovement();
	}

    void UpdateBools() {
        forward = backward = jump = crouch = use = false;

        forward = KC.GetKey("Forward");
        backward = KC.GetKey("Backward");
        jump = KC.GetKey("Jump");
        crouch = KC.GetKey("Down");

        use = KC.GetKeyDown("Use");
    }

    void ProcessAndSendMovement() {
        pm.Move(forward, backward, jump, crouch, use);
    }
}
