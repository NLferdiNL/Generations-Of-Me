using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tags.PLAYER)
        {
            other.GetComponent<PlayerMovement>();
        }
    }

}
