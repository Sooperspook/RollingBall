using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject gameManager; 
	
	void Awake () {

        if (GameManager.instance == null)   // Check if GameManager.instance is still null
            Instantiate(gameManager);       // If it is, instantiate gameManager prefab

        
	}
	
}
