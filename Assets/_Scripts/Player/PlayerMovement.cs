using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour {

    Transform tf;
    Rigidbody2D rb;

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
    float maxVelocity = 10;

    [SerializeField, Tooltip("Don't edit this unless you know what you're doing!")]
    float walkDivider = 30;

    [SerializeField, Tooltip("Don't edit this unless you know what you're doing!")]
    float jumpDivider = 1;

	void Start () {
        tf = transform;
        rb = GetComponent<Rigidbody2D>();
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
    public void Move(bool forward, bool backward, bool jump, bool suicide) {
        Vector3 toMove = new Vector3();
        float currentJumpHeight = jumpHeight / jumpDivider;
        float currentWalkSpeed = touchingGround ? groundSpeed / walkDivider : airSpeed / walkDivider;


        // Just make sure it doesn't do both.
        if (forward && backward) {
            forward = backward = false;
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

        if (suicide) {
            Suicide();
        }

        if (rb.velocity.y >= maxVelocity) {
            rb.velocity = new Vector2(rb.velocity.x, maxVelocity);
        }

        tf.position += toMove;
    }

    public void Suicide(bool outsideDeath = false) {
        // Maybe add some more stuff later?
        OnDeath(outsideDeath);
    }

    void OnDeath(bool outsideDeath = false) {
        Respawner respawner = Camera.main.GetComponent<Respawner>();

        if (!outsideDeath) {
            if (!respawner.TimedOut) {
                DeathHandling(respawner);
            }
        } else {
            DeathHandling(respawner, true);
        }
    }

    void DeathHandling(Respawner respawner, bool outsideDeath = false) {
        tf.Rotate(new Vector3(0, 0, 90));

        rb.isKinematic = true;
        respawner.Respawn(this.gameObject, outsideDeath);
        GetComponent<KeyboardInput>().enabled = this.enabled = false;
    }
}
