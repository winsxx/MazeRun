using UnityEngine;
using System.Collections;

public class ThrowScript : MonoBehaviour {
    public GameObject Bomb;
    public GameObject Dirt;
    public GameObject WhityBomb;
    private GameControlScript control;
    public float speed;
    private float timerBomb;
    private float timerDirt;
    public float timeBetweenAction;    
    public AudioClip clipExplosion;
    AudioSource throwAudio;
    private static bool ableBomb;
    private static bool ableDirt;

	// Use this for initialization
	void Start () {
        control = GameObject.Find("GameControl").GetComponent<GameControlScript>();        
        throwAudio = gameObject.AddComponent<AudioSource>();
        ableBomb = true;
        ableDirt = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!ableBomb)
        {
            timerBomb -= Time.deltaTime;
            if (timerBomb <= 0)
            {
                ableBomb = true;
            }
        }
        if (!ableDirt)
        {
            timerDirt -= Time.deltaTime;
            if (timerDirt <= 0)
            {
                ableDirt = true;
            }
        }
        if (Input.GetButton("Fire1") && ableBomb)
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
                timerBomb = timeBetweenAction;
                ableBomb = false;
                Destroy(bom, 4);
            }            
        }
        else if (Input.GetButton("Fire2") && ableDirt)
        {
            if (control.getTotDirt() > 0)
            {
                control.dirtUsed();
                StartCoroutine("lmprTanah");
                timerDirt = timeBetweenAction;
                ableDirt = false;
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
        GameObject tanah = Instantiate(Dirt, transform.position + 1.5f * transform.forward, transform.rotation) as GameObject;
        tanah.GetComponent<Rigidbody>().useGravity = true;
        tanah.GetComponent<Rigidbody>().AddForce(transform.forward * 80.0f, ForceMode.Force);
        //control.dirtUsed();
        yield return null;
    }
}
