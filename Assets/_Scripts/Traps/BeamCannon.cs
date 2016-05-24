using UnityEngine;
using System.Collections;

public class BeamCannon : MonoBehaviour
{
    // make timer for bool on/off
    bool isShooting = false;

    Respawner resp;

    [SerializeField]
    private float beamInterval;

    SpriteRenderer sprit;
    BoxCollider2D collBox2D;

    private bool firing = false;

    Respawner reps;

    void Start()
    {
        reps = Camera.main.GetComponent<Respawner>();
        sprit = gameObject.GetComponent<SpriteRenderer>();
        collBox2D = gameObject.GetComponent<BoxCollider2D>();
        StartCoroutine(BeamSwitch());
    }
    IEnumerator BeamSwitch()
    {
        yield return new WaitForSeconds(beamInterval);
        firing = !firing;



        if(firing)
        {
            sprit.enabled = true;
            collBox2D.enabled = true;
            // turn particle systems on
            // cant do this without the SYSTEMS
        }
        else
        {
            collBox2D.enabled = false;
            sprit.enabled = false;
        }
        StartCoroutine(BeamSwitch());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (firing && other.tag == Tags.PLAYER)
        {
            resp.Respawn(other.gameObject);
        }
    }
}
