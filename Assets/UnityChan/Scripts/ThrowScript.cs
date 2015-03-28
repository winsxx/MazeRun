using UnityEngine;
using System.Collections;
using System;

public class ThrowScript : MonoBehaviour {
    public GameObject Bomb;
    public GameObject Dirt;
    public GameObject WhityBomb;
    private GameControlScript control;
    public float speed;

	// Use this for initialization
	void Start () {
        control = GameObject.Find("GameControl").GetComponent<GameControlScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            if (control.getTotBomb() > 0)
            {
                control.bombUsed();
                //Console.WriteLine("Jmlh Bomb skrg : " + control.getTotBomb());
                Vector3 posisi_skrg = transform.position - new Vector3(0,1f,0) + 7.5f * transform.forward;
                GameObject bom = Instantiate(Bomb, transform.position + transform.forward, transform.rotation) as GameObject;
                bom.GetComponent<Rigidbody>().useGravity = true;
                bom.GetComponent<Rigidbody>().AddForce(transform.forward * 80.0f, ForceMode.Force);
                StartCoroutine(efekLedak(1f, posisi_skrg));
                Destroy(bom, 4);
            }            
        }
        else if (Input.GetButton("Fire2"))
        {
            if (control.getTotDirt() > 0)
            {
                control.dirtUsed();
                /*Rigidbody rbTanah ;
                rbTanah= (Rigidbody) Instantiate(Dirt, transform.position, transform.rotation) as Rigidbody;                                
                rbTanah.velocity = transform.TransformDirection(Vector3.forward*10);*/
                //rbTanah.AddForce(transform.forward * 100.0f,ForceMode.Force);

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
        Destroy(efek_bom, 2);
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
