using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public void onClickLevel1(){
		Application.LoadLevel ("Level1");
	}

	public void onClickLevel2(){
		Application.LoadLevel ("Level2");
	}
}
