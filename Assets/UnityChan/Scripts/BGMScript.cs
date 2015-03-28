using UnityEngine;
using System.Collections;

public class BGMScript : MonoBehaviour {
    public AudioClip clipBGM;
    private AudioSource audioBGM;

	// Use this for initialization
	/*void Start () {
        audioBGM = gameObject.AddComponent<AudioSource>();
        audioBGM.loop = true;
        audioBGM.volume = 0.1f;
	}*/
	
	// Update is called once per frame
	void Update () {
	
	}

    void Awake()
    {

    }
}
