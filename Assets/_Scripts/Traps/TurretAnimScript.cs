using UnityEngine;
using System.Collections;

public class TurretAnimScript : MonoBehaviour
{

    Animator anim;
    public float rotation;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {        
        anim.SetFloat("Rotation", rotation);
    }
}
