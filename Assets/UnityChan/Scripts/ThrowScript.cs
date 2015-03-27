using UnityEngine;
using System.Collections;
public class ThrowScript : MonoBehaviour {
    public GameObject Bomb;
    public GameObject Dirt;
    public GameObject WhityBomb;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            Vector3 posisi_skrg=transform.position + 7.0f * transform.forward;
            GameObject bom = Instantiate(Bomb, posisi_skrg, transform.rotation) as GameObject;
            StartCoroutine(efekLedak(4.5f, posisi_skrg));
            Destroy(bom, 5);            
        }
        else if (Input.GetButton("Fire2"))
        {
            Instantiate(Dirt, transform.position + 7.0f * transform.forward, transform.rotation);
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
    }
}
