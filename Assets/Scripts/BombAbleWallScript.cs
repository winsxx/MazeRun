using UnityEngine;
using System.Collections;

public class BombAbleWallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WhiteBomb")
        {
            Destroy(this.gameObject);
        }        
    }
}
