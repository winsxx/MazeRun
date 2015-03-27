using UnityEngine;
using System.Collections;
using RAIN.Core;

public class EnemyShotController : MonoBehaviour {

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
			rig.AI.WorkingMemory.SetItem<int>("myHealth", health-25);
		}
	}
}
