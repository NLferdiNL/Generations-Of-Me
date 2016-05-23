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
        print(other.tag == Tags.PLAYER);
        if (other.tag == Tags.PLAYER)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                resp.Respawn(other.gameObject, true);
            }
        }
        if(other.tag != Tags.PROJECTILE)
            Destroy(gameObject);
    }
}