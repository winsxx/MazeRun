using UnityEngine;
using System.Collections;
public class ThrowScript : MonoBehaviour {
    public GameObject Bomb;
    public GameObject Dirt;
    public GameObject WhityBomb;
    private GameControlScript control;

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
                Vector3 posisi_skrg = transform.position + 7.0f * transform.forward;
                GameObject bom = Instantiate(Bomb, posisi_skrg, transform.rotation) as GameObject;
                StartCoroutine(efekLedak(4.5f, posisi_skrg));
                Destroy(bom, 5);
            }            
        }
        else if (Input.GetButton("Fire2"))
        {
            if (control.getTotDirt() > 0)
            {
                control.dirtUsed();
                Instantiate(Dirt, transform.position + 7.0f * transform.forward, transform.rotation);
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
    }
}
