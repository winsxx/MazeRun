//
// Unityちゃん用の三人称カメラ
// 
// 2013/06/07 N.Kobyasahi
//
using UnityEngine;
using System.Collections;

namespace UnityChan
{
	public class ThirdPersonCamera : MonoBehaviour
	{
		public float smooth = 3f;		// カメラモーションのスムーズ化用変数
		Transform standardPos;			// the usual position for the camera, specified by a transform in the game
		Transform frontPos;			// Front Camera locater
		Transform jumpPos;			// Jump Camera locater
		
		public AudioClip clipBGM;
		private AudioSource audioBGM;
	
		// スムーズに繋がない時（クイック切り替え）用のブーリアンフラグ
		bool bQuickSwitch = false;	//Change Camera Position Quickly
	
		bool isStart;
		
		AudioSource AddAudio(AudioClip clip){
			AudioSource newAudio = gameObject.AddComponent<AudioSource>();
			newAudio.clip = clip;
			return newAudio;
		}
		
		void StartGame(){
			isStart = true;
			audioBGM.Play ();
			setCameraPositionNormalView ();
		}
		
		void Awake(){
			audioBGM = AddAudio(clipBGM);
			audioBGM.loop = true;
			audioBGM.volume = 0.1f;
		}
		
		void Start ()
		{
			// 各参照の初期化
			standardPos = GameObject.Find ("CamPos").transform;
		
			if (GameObject.Find ("FrontPos"))
				frontPos = GameObject.Find ("FrontPos").transform;

			if (GameObject.Find ("JumpPos"))
				jumpPos = GameObject.Find ("JumpPos").transform;

			//カメラをスタートする
			transform.position = standardPos.position;	
			transform.forward = standardPos.forward;
			isStart = false;
			setCameraPositionFrontView ();
			Invoke ("StartGame",7f);
		}
	
		void FixedUpdate ()	// このカメラ切り替えはFixedUpdate()内でないと正常に動かない
		{
			if (isStart){
				if (Input.GetButton ("Fire1")) {	// left Ctlr	
					// Change Front Camera
					setCameraPositionFrontView ();
				} else if (Input.GetButton ("Fire2")) {	//Alt	
					// Change Jump Camera
					setCameraPositionJumpView ();
				} else {	
					// return the camera to standard position and direction
					setCameraPositionNormalView ();
				}
			}
		}

		void setCameraPositionNormalView ()
		{
			if (bQuickSwitch == false) {
				// the camera to standard position and direction
				transform.position = Vector3.Lerp (transform.position, standardPos.position, Time.fixedDeltaTime * smooth);	
				transform.forward = Vector3.Lerp (transform.forward, standardPos.forward, Time.fixedDeltaTime * smooth);
			} else {
				// the camera to standard position and direction / Quick Change
				transform.position = standardPos.position;	
				transform.forward = standardPos.forward;
				bQuickSwitch = false;
			}
		}
	
		void setCameraPositionFrontView ()
		{
			// Change Front Camera
			bQuickSwitch = true;
			transform.position = frontPos.position;	
			transform.forward = frontPos.forward;
		}

		void setCameraPositionJumpView ()
		{
			// Change Jump Camera
			bQuickSwitch = false;
			transform.position = Vector3.Lerp (transform.position, jumpPos.position, Time.fixedDeltaTime * smooth);	
			transform.forward = Vector3.Lerp (transform.forward, jumpPos.forward, Time.fixedDeltaTime * smooth);		
		}
	}
}