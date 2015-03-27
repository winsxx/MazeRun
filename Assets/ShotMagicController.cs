using UnityEngine;
using System.Collections;

public class ShotMagicController : MonoBehaviour {
	public GameObject magicBall;
	public float spawnDistance = 1.0f;
	public float delay = 1000000f;
	private float currentDelay = 0;

	// Use this for initialization
	void Start () {
		currentDelay = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Jump") && currentDelay <= 0.001) {
			ShotMagic();
			currentDelay = delay;
		}	
		currentDelay -= Time.deltaTime;
		if (currentDelay < 0)
			delay = 0;
	}

	void ShotMagic(){
		MagicBulletController magicBallClone = 
			Instantiate(magicBall, transform.position, transform.rotation) as MagicBulletController;
	}
}
