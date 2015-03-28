using UnityEngine;
using System.Collections;

public class PlayerKenaBomb : MonoBehaviour {

    private GameControlScript control;

	// Use this for initialization
	void Start () {
        control = GameObject.Find("GameControl").GetComponent<GameControlScript>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WhiteBomb")
        {
            control.reduceHealth(40);
        }        
    }
}
