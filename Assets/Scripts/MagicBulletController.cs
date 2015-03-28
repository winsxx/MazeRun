using UnityEngine;
using System.Collections;

public class MagicBulletController : MonoBehaviour {
	public float maxLifetime;
	public float speed;

	// Use this for initialization
	void Start () {
		rigidbody.velocity = transform.TransformDirection ( new Vector3 (0, 0, speed));
		Destroy (this.gameObject, maxLifetime);
	}

}
