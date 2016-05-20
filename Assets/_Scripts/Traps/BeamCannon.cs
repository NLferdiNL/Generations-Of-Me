using UnityEngine;
using System.Collections;

public class BeamCannon : MonoBehaviour
{
    Respawner reps;

    void Start()
    {
        reps = Camera.main.GetComponent<Respawner>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tags.Player)
        {
            reps.Respawn(other.gameObject);
        }
    }
}
