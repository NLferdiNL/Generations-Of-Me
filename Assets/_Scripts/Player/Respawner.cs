using System.Collections;
using UnityEngine;

public class Respawner : MonoBehaviour
{

    [SerializeField]
    GameObject cloneBody;

    GameObject lastBody;

    Transform respawn;

    CamController2D camCon2D;

    bool timedOut = false;

    public bool TimedOut
    {
        get
        {
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

    int maxLives;

    public int Lives
    {
        get { return lives; }
    }

    public int MaxLives
    {
        get { return maxLives; }
    }

    void Start()
    {
        respawn = GameObject.FindWithTag("Respawn").GetComponent<Transform>();
        camCon2D = Camera.main.GetComponent<CamController2D>();
        if (lives > 0)
        {
            infiniteBodies = true;
            workingWithLives = true;
            maxLives = lives;
        }
    }

    public void Respawn(GameObject bodyToDiscard, bool outsideDeath = false)
    {
        if (!timedOut || outsideDeath)
        {
            if (workingWithLives)
            {
                if (lives > 0 || outsideDeath)
                {
                    lives--;
                    if (lives < 0)
                        lives = 0;
                }
                else {
                    return;
                }
            }

            if (!infiniteBodies)
                Destroy(lastBody);

            lastBody = bodyToDiscard;

            if (lives >= 0)
            {
                //GameObject currentBody = Instantiate(cloneBody);
                //currentBody.transform.position = respawn.position;

                //camCon2D.Target = currentBody.transform;
            }

            lastBody.layer = LayerMask.NameToLayer("Ground");

            GameObject currentBody = Instantiate(cloneBody);
            currentBody.transform.position = respawn.position;

            StartCoroutine(TimeOut());
        }
    }

    IEnumerator TimeOut()
    {
        timedOut = true;
        yield return new WaitForSeconds(timeOutDelay);
        if (workingWithLives)
        {
            if (lives <= 0)
            {
                // This prevents the player from commiting suicide next time.
                timedOut = true;
            }
            else {
                timedOut = false;
            }
        }
        else {
            timedOut = false;
        }
    }
}
