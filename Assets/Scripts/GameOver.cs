using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	public Texture GameOverBackground;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), GameOverBackground);
		GUI.Label (new Rect (20, 50, 500, 75), "<size=50><color=navy>GAMEOVER</color></size>");
		GUI.Label(new Rect(20, 125, 500, 75), "<size=30><color=teal>YOUR SCORE IS "+PlayerPrefs.GetInt("Score")+"</color></size>");
		if(GUI.Button(new Rect(20, Screen.height-70, 200, 50), "<size=20>Back to main menu</size>")){
			Application.LoadLevel(0);
			PlayerPrefs.DeleteAll();
		}
	}
}
