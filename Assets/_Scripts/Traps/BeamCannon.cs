using UnityEngine;
using System.Collections;

public class BeamCannon : MonoBehaviour
{
    // make timer for bool on/off
    bool isShooting = false;

    Respawner resp;

    [SerializeField]
    private float beamInterval;

    ParticleSystem pars;

    private bool firing = false;

    Respawner reps;

    void Start()
    {
        reps = Camera.main.GetComponent<Respawner>();
        pars = GetComponent<ParticleSystem>();
        StartCoroutine(BeamSwitch(0));
    }
    IEnumerator BeamSwitch(float switchtime)
    {
        yield return new WaitForSeconds(beamInterval);
        firing = !firing;



        if(firing)
        {

        }
        StartCoroutine(BeamSwitch(beamInterval));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (firing && other.tag == Tags.PLAYER)
        {
            reps.Respawn(other.gameObject);
        }
    }
}
