using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    Transform tf;
    //Rigidbody2D rb = RequireComponent<Rigidbody2D>();

    bool touchingGround = false;

    [Header("Movement variables")]

    [SerializeField, Tooltip("The speed at which I traverse on ground.")]
    float groundSpeed;

    [SerializeField, Tooltip("The speed at which I traverse in the air.")]
    float airSpeed;

    [SerializeField, Tooltip("The height at which I jump.")]
    float jumpHeight;

    [SerializeField, Tooltip("Layer name for ground.")]
    string ground = "Ground";

    [Header("Misc. variables")]
    [SerializeField, Tooltip("Don't edit this unless you know what you're doing!")]
    float walkDivider;
    
    [SerializeField, Tooltip("Don't edit this unless you know what you're doing!")]
    float jumpDivider;

	void Start () {
        tf = transform;
        //rb = RequireComponent<Rigidbody2D>();
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (LayerCheck(other.gameObject.layer)) {
            touchingGround = true;
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if (LayerCheck(other.gameObject.layer)) {
            touchingGround = true;
        }
    }

    bool LayerCheck(int layer) {
        if (layer == LayerMask.NameToLayer(ground)) {
            return true;
        }
        return false;
    }

    void OnTriggerExit2D(Collider2D other) {
        if (LayerCheck(other.gameObject.layer)) {
            touchingGround = false;
        }
    }

	// Move is called once per frame
    public void Move(bool forward, bool backward, bool jump, bool crouch, bool use) {
        Vector3 toMove = new Vector3();
        float currentJumpHeight = jumpHeight / jumpDivider;
        float currentWalkSpeed = touchingGround ? groundSpeed / walkDivider : airSpeed / walkDivider;


        // Just make sure it doesn't do both.
        if (forward && backward) {
            forward = backward = false;
        }

        if (jump && crouch) {
            jump = crouch = false;
        }

        if (forward) {
            toMove += tf.right * currentWalkSpeed;
        } else if (backward) {
            toMove += -tf.right * currentWalkSpeed;
        }

        if (jump && touchingGround) {
            //rb.AddForce(tf.up * currentJumpHeight, ForceMode2D.Impulse);
            touchingGround = false;
        }

        if (use) {
            OnDeath();
        }

        tf.position += toMove;
    }

    void OnDeath() {
        tf.Rotate(new Vector3(0, 0, 90));
    }
}
