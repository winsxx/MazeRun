using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text highscoreLv1;
	public Text highscoreLv2;

	// Use this for initialization
	void Start () {
		int lv1 = PersistentScore.getHighScore (1);
		int lv2 = PersistentScore.getHighScore (2);
		highscoreLv1.text = "Score: " + lv1.ToString();
		highscoreLv2.text = "Score: " + lv2.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
