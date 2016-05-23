using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletLifeTime = 2;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private GameObject turret;
    // Use this for initialization
    Respawner resp;

    void Start()
    {
        resp = Camera.main.GetComponent<Respawner>();
        Destroy(gameObject, bulletLifeTime);
    }

    void Update()
    {
        transform.Translate(turret.transform.up * bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tags.Player)
        {
            resp.Respawn(other.gameObject);
            Destroy(gameObject);
        }
    }
}