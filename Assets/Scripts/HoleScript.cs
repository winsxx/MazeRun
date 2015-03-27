using UnityEngine;
using System.Collections;

public class HoleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dirt")
        {
            Destroy(this.gameObject);
        }
    }
}
