using UnityEngine;
using System.Collections;
using System;

public class ThrowScript : MonoBehaviour {
    public GameObject Bomb;
    public GameObject Dirt;
    public GameObject WhityBomb;
    private GameControlScript control;
    public float speed;
    private float timer;
    public float timeBetweenAction;    
    public AudioClip clipExplosion;
    AudioSource throwAudio;
    private static bool able;

	// Use this for initialization
	void Start () {
        control = GameObject.Find("GameControl").GetComponent<GameControlScript>();        
        throwAudio = gameObject.AddComponent<AudioSource>();
        able = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!able)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                able = true;
            }
        }
        if (Input.GetButton("Fire1") && able)
        {
            if (control.getTotBomb() > 0)
            {                                
                Vector3 posisi_skrg = transform.position - new Vector3(0,1f,0) + 8f * transform.forward;
                GameObject bom = Instantiate(Bomb, transform.position + transform.forward, transform.rotation) as GameObject;
                bom.GetComponent<Rigidbody>().useGravity = true;
                bom.GetComponent<Rigidbody>().AddForce(transform.forward * 80.0f, ForceMode.Force);
                StartCoroutine(efekLedak(1f, posisi_skrg));                
                throwAudio.clip=clipExplosion;
                throwAudio.Play();
                control.bombUsed();
                timer = timeBetweenAction;
                able = false;
                Destroy(bom, 4);
            }            
        }
        else if (Input.GetButton("Fire2") && able)
        {
            if (control.getTotDirt() > 0)
            {
                control.dirtUsed();
                timer = timeBetweenAction;
                able = false;
                StartCoroutine("lmprTanah");
            }            
        }
	}

    IEnumerator efekLedak(float waktu,Vector3 posisi)
    {       
        for (float it = 0; it < waktu; it += Time.deltaTime)
        {
            yield return null;
        }
        GameObject efek_bom = Instantiate(WhityBomb, posisi, transform.rotation) as GameObject;        
        Destroy(efek_bom, 3);
        //control.bombUsed();
    }

    IEnumerator lmprTanah()
    {        
        GameObject tanah = Instantiate(Dirt, transform.position + transform.forward, transform.rotation) as GameObject;
        tanah.GetComponent<Rigidbody>().useGravity = true;
        tanah.GetComponent<Rigidbody>().AddForce(transform.forward * 80.0f, ForceMode.Force);
        //control.dirtUsed();
        yield return null;
    }
}
