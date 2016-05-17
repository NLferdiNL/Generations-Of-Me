using UnityEngine;

public class PlayerDamage : MonoBehaviour {

    [SerializeField]
    string damageTag = "Danger";

    PlayerMovement pm;

    void Start() {
        pm = GetComponent<PlayerMovement>();
    }

	void OnCollisionEnter2D (Collision2D other) {
	    if(other.gameObject.tag == damageTag) {
            pm.Suicide(true);
        }
	}
}
