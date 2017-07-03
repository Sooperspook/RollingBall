using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float torqueSpeed;
 
    public Text countText;
    public Text winText;

    private Rigidbody player;
    private int count;

    void Start()
    {
        player = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
    }

void FixedUpdate ()
    {

        // Using torque to move the player.
        // moveForeward also moves backward, moveTurn causes it to spin
        // problem: once it starts moving, because axes move, hard to control

        float moveForeward = Input.GetAxis("Vertical");
        player.AddTorque(transform.forward * torqueSpeed * moveForeward);

        float moveTurn = Input.GetAxis("Horizontal");
        player.AddTorque(transform.up * torqueSpeed * moveTurn);
    }

    // Upon touching another object, test what kind of object and act accordingly
    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText ();
        }

   
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 6)
        {
            winText.text = "You Win";
        }
    }
}

