using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
	private float gameTime;
	private int Score;
	private int Life;
	private int soilItem;
	private int bombItem;
	private int otherItem;
	public Texture bombIcon;
	public Texture dirtIcon;

	// Use this for initialization
	void Start () {
		gameTime = 300;
		Score = 0;
		Life = 3;
		soilItem = 5;
		bombItem = 5;
		otherItem = 5;
	}
	
	// Update is called once per frame
	void Update () {
		gameTime -= Time.deltaTime;
		if (gameTime == 0) {
			// GameOver();
		}
	}

	void OnGUI () {
		GUI.Label (new Rect (5, 5, 200, 50), "<size=20>SCORE\n"+Score+"</size>");
		GUI.Label (new Rect (Screen.width/2-75, 5, 150, 25), "<size=20>TIME LEFT</size>");
		GUI.Label (new Rect (Screen.width/2-40, 30, 80, 25), "<size=20>"+(int)gameTime+"</size>");
		GUI.Label (new Rect (5, Screen.height-30, 200, 50), "<size=20>"+Life+" PLAY(s) LEFT</size>");
		GUI.DrawTexture(new Rect (Screen.width-180, Screen.height-80, 75, 75), bombIcon);
		GUI.Label (new Rect (Screen.width - 160, Screen.height - 40, 100, 50), "<size=20>1</size>");
		GUI.DrawTexture(new Rect (Screen.width-95, Screen.height-70, 90, 90), dirtIcon);
		GUI.Label (new Rect (Screen.width - 60, Screen.height - 40, 100, 50), "<size=20>1</size>");
	}
}
