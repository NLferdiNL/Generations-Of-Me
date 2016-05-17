using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    private int coinCount;

    public GameObject coinCountText;

    Text _coinCountTextField;
    // Use this for initialization
    void Start()
    {
        _coinCountTextField = coinCountText.GetComponent<Text>();
        coinCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _coinCountTextField.text = "Coins: " + coinCount;
    }

    void OnTriggerEnter2d(Collider2D other)
    {
        if (other.tag == Tags.Player)
        {
            coinCount++;
            Destroy(gameObject);
        }
    }

}
