using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private GameObject turret;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(DestroyBullet(3f));
    }

    IEnumerator DestroyBullet(float destroyTimer)
    {
        yield return new WaitForSeconds(destroyTimer);
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(turret.transform.up * bulletSpeed * Time.deltaTime);
    }
}