using UnityEngine;
using System.Collections;

public class Respawner : MonoBehaviour {

    [SerializeField]
    GameObject cloneBody;

    GameObject currentBody;
    GameObject lastBody;

    Transform respawn;

    void Start() {
        respawn = GameObject.FindWithTag("Respawn").GetComponent<Transform>(); ;
    }

    public void Respawn() {
        Destroy(lastBody);

        lastBody = currentBody;

        currentBody = Instantiate(cloneBody);
        currentBody.transform.position = respawn.position;
    }
}
