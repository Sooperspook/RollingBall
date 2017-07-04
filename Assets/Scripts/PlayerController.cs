using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float torqueSpeed;
    public Vector3 previousTorque;
    public Text countText;
    public Text winText;

    private Rigidbody player;
    private int count;

    void Start()
    {
        player = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "Woot";
    }

void FixedUpdate ()
    {

        // Using torque to move the player.
       
        var inputRot = Camera.main.transform.rotation;
        var tmp = inputRot.eulerAngles;

        tmp.x = 0;
        tmp.z = 0;
        inputRot = Quaternion.Euler(tmp);

        var torqueDir = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal")).normalized;
        torqueDir = inputRot * torqueDir;

        previousTorque = torqueDir * torqueSpeed;

        player.AddTorque(previousTorque);

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

