using UnityEngine;
using System.Collections;

public class GameControlScript : MonoBehaviour {
	public float gameTime;
	private int Score;
	private int Health;
	private int bombCount;
	private int dirtCount;
	private int coinCount;
	public Texture bombIcon;
	public Texture dirtIcon;
	public int level;
	private bool isFinishReached;

	// Use this for initialization
	void Start () {
		Score = 0;
		Health = 100;
		bombCount = 0;
		dirtCount = 0;
		coinCount = 0;
		isFinishReached = false;        
	}
	
	// Update is called once per frame
	void Update () {
		gameTime -= Time.deltaTime;
		if (gameTime <= 0 || isFinishReached == true || Health<=0) {
			GameOver();
		}
	}

	public void bombCollected() {
		bombCount++;
	}

	public void dirtCollected() {
		dirtCount++;
	}

	public void coinCollected() {
		coinCount++;
		Score += 100;
	}

	public void finishTrophyCollected() {
		isFinishReached = true;
	}

	public void reduceHealth(int ammount){
		Health -= ammount;
	}

    public void bombUsed()
    {
        bombCount--;
    }

    public void dirtUsed()
    {
        dirtCount--;
    }

    public int getTotBomb()
    {
        return bombCount;
    }

    public int getTotDirt()
    {
        return dirtCount;
    }

	void OnGUI () {
		// Timer
		GUI.Label (new Rect (5, 5, 200, 50), "<size=20>SCORE\n"+Score+"</size>");
		GUI.Label (new Rect (Screen.width/2-75, 5, 150, 25), "<size=20>TIME LEFT</size>");

		// Life
		GUI.Label (new Rect (Screen.width/2-40, 30, 80, 25), "<size=20>"+(int)gameTime+"</size>");
		GUI.Label (new Rect (5, Screen.height-30, 200, 50), "<size=20> HEALTH = "+Health+"</size>");

		// Bomb
		GUI.DrawTexture(new Rect (Screen.width-180, Screen.height-80, 75, 75), bombIcon);
		GUI.Label (new Rect (Screen.width - 160, Screen.height - 40, 100, 50), "<size=20>"+bombCount+"</size>");

		// Dirt
		GUI.DrawTexture(new Rect (Screen.width-95, Screen.height-70, 90, 90), dirtIcon);
		GUI.Label (new Rect (Screen.width - 60, Screen.height - 40, 100, 50), "<size=20>"+dirtCount+"</size>");
	}

	private void GameOver() {
		PlayerPrefs.SetInt ("Score", Score);
		string finishStatus = isFinishReached ? "true" : "false";
		PlayerPrefs.SetString ("finishStatus", finishStatus);
		if(isFinishReached)
			PersistentScore.addHighScore(level,Score);
		Application.LoadLevel (3);
	}
}
