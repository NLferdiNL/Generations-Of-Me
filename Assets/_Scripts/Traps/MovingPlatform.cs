using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    //the target location for when they door move
    public Transform doorTarget;

    //Speed of the door's movement
    [SerializeField]
    private float speed;

    void Awake()
    {
        doorTarget = GameObject.FindGameObjectWithTag(Tags.PlatformTarget).transform;
    }

    //The update checks if the doorUp is true. And if it is it, moves the door
    void Update()
    {

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, doorTarget.position, step);
    }
}