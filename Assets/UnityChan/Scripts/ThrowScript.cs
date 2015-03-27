using UnityEngine;
using System.Collections;

public class ThrowScript : MonoBehaviour {

    public GameObject Bomb;
    public GameObject Dirt;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            Instantiate(Bomb, transform.position + 7.0f * transform.forward, transform.rotation);
        }
        else if (Input.GetButton("Fire2"))
        {
            Instantiate(Dirt, transform.position + 7.0f * transform.forward, transform.rotation);
        }
	}
}
