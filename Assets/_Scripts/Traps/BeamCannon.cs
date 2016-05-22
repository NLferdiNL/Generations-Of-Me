using UnityEngine;
using System.Collections;

public class BeamCannon : MonoBehaviour
{
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (firing && other.tag == Tags.Player)
        {
            reps.Respawn(other.gameObject);
        }
    }
}
