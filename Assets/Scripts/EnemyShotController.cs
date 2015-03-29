using UnityEngine;
using System.Collections;
using RAIN.Core;

public class EnemyShotController : MonoBehaviour {

	public GameObject attackEffectPrefab;
	public int healthReducePerAttack;
	public AudioSource sound;

	AIRig rig = null;

	// Use this for initialization
	void Start () {
		rig = gameObject.GetComponentInChildren<AIRig>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Bullet") {
			int health = rig.AI.WorkingMemory.GetItem<int>("myHealth");
			rig.AI.WorkingMemory.SetItem<int>("myHealth", health-healthReducePerAttack);

			if(sound!=null)
				sound.Play();
			GameObject tempEffect = Instantiate(attackEffectPrefab,other.transform.position, Quaternion.identity) as GameObject;

			Destroy(other.gameObject);
			Destroy(tempEffect.gameObject, 1f);
		}
	}
}
