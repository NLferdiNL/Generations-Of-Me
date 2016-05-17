using UnityEngine;
using System.Collections;

public class Respawner : MonoBehaviour {

    [SerializeField]
    GameObject cloneBody;

    GameObject lastBody;

    Transform respawn;

    bool timedOut = false;

    public bool TimedOut {
        get {
            return timedOut;
        }
    }

    [SerializeField]
    float timeOutDelay = 1f;

    [SerializeField, Tooltip("If value is above 0, player can commit suicide this many times before being unable to do so again.")]
    int lives = 0;

    bool workingWithLives = false;

    [Header("FOR DEBUG ONLY:")]
    [SerializeField, Tooltip("While this is available to enable yourself, it's mainly used by the lives. It's adviced to leave this off as the user can cause mayham.")]
    bool infiniteBodies = false;

    void Start() {
        respawn = GameObject.FindWithTag("Respawn").GetComponent<Transform>();
        if (lives > 0) {
            infiniteBodies = true;
            workingWithLives = true;
        }
    }

    public void Respawn(GameObject bodyToDiscard) {
        if (!timedOut) {
            if (workingWithLives) {
                if (lives > 0) {
                    lives--;
                } else {
                    return;
                }
            }

            if(!infiniteBodies)
                Destroy(lastBody);
            lastBody = bodyToDiscard;

            lastBody.layer = LayerMask.NameToLayer("Ground");

            GameObject currentBody = Instantiate(cloneBody);
            currentBody.transform.position = respawn.position;

            StartCoroutine(TimeOut());
        }
    }

    IEnumerator TimeOut() {
        timedOut = true;
        yield return new WaitForSeconds(timeOutDelay);
        if (workingWithLives) {
            if (lives <= 0) {
                // This prevents the player from commiting suicide next time.
                timedOut = true;
            } else {
                timedOut = false;
            }
        } else {
            timedOut = false;
        }
    }
}
