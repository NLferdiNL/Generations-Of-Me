using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
    public float DeathCount;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2d(Collider2D other)
    {
        if (other.tag == Tags.Player)
        {
            //DeathCount theCount = other.gameObject.GetComponent<DeathCount>();
            //theCount.addLive(DeathCount);
            //Destroy(gameObject);
        }
    }

}
