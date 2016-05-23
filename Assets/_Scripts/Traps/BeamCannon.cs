using UnityEngine;
using System.Collections;

public class BeamCannon : MonoBehaviour
{
<<<<<<< HEAD
    // make timer for bool on/off
    bool isShooting = false;

    Respawner resp;

    void Start()
    {
        resp = Camera.main.GetComponent<Respawner>();
=======
    [SerializeField]
    private float beamInterval;

    private bool firing = false;

    Respawner reps;

    void Start()
    {
        reps = Camera.main.GetComponent<Respawner>();
        StartCoroutine(BeamSwitch(0));
    }
    IEnumerator BeamSwitch(float switchtime)
    {
        yield return new WaitForSeconds(beamInterval);
        firing = !firing;
        StartCoroutine(BeamSwitch(beamInterval));
>>>>>>> origin/master
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (firing && other.tag == Tags.Player)
        {
            resp.Respawn(other.gameObject);
        }
    }
}
