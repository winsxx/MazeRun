using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {
	private float floatSpeed = .5F;
	private float floatTime = 0F;
	private float floatDistance = .01F;
	private float rotateSpeed = 4F;
	private GameControlScript control;
    public AudioClip clipCoin;    

	// Use this for initialization
	void Start () {
		control = GameObject.Find ("GameControl").GetComponent<GameControlScript> ();        
	}
	
	// Update is called once per frame
	void Update () {
		floatTime += Time.deltaTime * floatSpeed;
		transform.Translate(0F, Mathf.Sin (Mathf.PI * 2 * floatTime) * floatDistance, 0F);

		transform.Rotate (0F, rotateSpeed, 0F);
	}

	void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            control.coinCollected();
            AudioSource.PlayClipAtPoint(clipCoin, transform.position);
            Destroy(this.gameObject);
        }     
	}
}
