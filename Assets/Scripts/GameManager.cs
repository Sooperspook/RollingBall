using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;  // This will be the only instance in the game and will be accessible by other scripts
    public int playerScore = 0;

	    // Changed to Awake so it starts before any Start function
	void Awake () {

        if (instance == null)       //checking if it already exits

            instance = this;        // If no other exists, this is it

        else if (instance != this)  // If one already exists...
            Destroy(gameObject);    // ...destroy this one and use the other one

        // So this is not destroyed on scene changes
        DontDestroyOnLoad(gameObject);
	}
	
    public void GameOver()
    {
        enabled = false;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
