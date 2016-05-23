using UnityEngine;
using System.Collections;

public class BeamCannon : MonoBehaviour
{
    // make timer for bool on/off
    bool isShooting = false;

    Respawner resp;

    void Start()
    {
        resp = Camera.main.GetComponent<Respawner>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tags.Player)
        {
            resp.Respawn(other.gameObject);
        }
    }
}
