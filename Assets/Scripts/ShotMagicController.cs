using UnityEngine;
using System.Collections;

public class ShotMagicController : MonoBehaviour {
	public GameObject magicBall;
	public int damagePerShot;
	public float timeBetweenBullets;
	public float attakDelay;
	private static bool able;

	private float timer;
	// Use this for initialization
	void Start () {
		able = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!able) {
			timer-=Time.deltaTime;
			if(timer<=0){
				able=true;
			}
		}
		if (Input.GetButton ("Jump") && able) {
			float temp = attakDelay;
			while(temp > 0)
				temp-=Time.deltaTime;
			ShotMagic();
			timer=timeBetweenBullets;
			able=false;
		}	
	}

	void ShotMagic(){
		MagicBulletController magicBallClone = 
			Instantiate(magicBall, transform.position, transform.rotation) as MagicBulletController;
	}
}
