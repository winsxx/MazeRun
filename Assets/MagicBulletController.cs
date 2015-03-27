using UnityEngine;
using System.Collections;

public class MagicBulletController : MonoBehaviour {
	public float maxRange = 5f;
	public float speed = 100f;
	private float currentRange;

	// Use this for initialization
	void Start () {
		currentRange = 0f;
		rigidbody.velocity = transform.TransformDirection ( new Vector3 (0, 0, speed));
		Destroy (this.gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
