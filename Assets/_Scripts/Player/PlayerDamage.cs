using UnityEngine;

public class PlayerDamage : MonoBehaviour {

    [SerializeField]
    string damageTag = "Danger";

    Transform tf;
    Rigidbody2D rb;

    void Start() {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

	void OnCollisionEnter2D (Collision2D other) {
	    if(other.gameObject.tag == damageTag) {
            Suicide();
        }
	}

    public void Suicide(bool forcedByRespawner = false) {
        Respawner respawner = Camera.main.GetComponent<Respawner>();
        if (forcedByRespawner) {
            DeathHandling();
        } else if (!respawner.TimedOut) {
            OnDeath();
        }
    }

    void OnDeath() {
        // Maybe add some more stuff later?

        DeathHandling();
    }

    void DeathHandling() {
        tf.Rotate(new Vector3(0, 0, 90));
        rb.isKinematic = true;
        GetComponent<KeyboardInput>().enabled = this.enabled = false;
    }
}
