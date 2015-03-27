using UnityEngine;
using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {
	private float floatSpeed = .5F;
	private float floatTime = 0F;
	private float floatDistance = .01F;
	private float rotateSpeed = 4F;
	private GameControlScript control;
	
	// Use this for initialization
	void Start () {
		control = GameObject.Find ("GameControl").GetComponent<GameControlScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		floatTime += Time.deltaTime * floatSpeed;
		transform.Translate(0F, 0F, Mathf.Sin (Mathf.PI * 2 * floatTime) * floatDistance);
		
		transform.Rotate (0F, 0F, rotateSpeed);
	}
	
	void OnTriggerEnter(Collider other) {
		control.bombCollected ();
		Destroy (this.gameObject);
	}
}

