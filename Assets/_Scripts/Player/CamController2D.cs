using UnityEngine;

public class CamController2D : MonoBehaviour
{
    [SerializeField]
    float dampTime = 0.15f;
    Vector3 velocity = Vector3.zero;
    [SerializeField]
    Transform target;
    Camera cam;

<<<<<<< HEAD
    [SerializeField] float dampTime = 0.15f; Transform target;
    Vector3 velocity = Vector3.zero;
    Camera cam;
=======
    public Transform Target {
        get {
            return target;
        }
        set {
            target = value;
        }
    }
>>>>>>> 6fe5030fa86b1d560c2dddf5ed476d7c2b7e7734

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }
    void Follow()
    {
        if (target)
        {
            Vector3 point = cam.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}