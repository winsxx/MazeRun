//
// Mecanimのアニメーションデータが、原点で移動しない場合の Rigidbody付きコントローラ
// サンプル
// 2014/03/13 N.Kobyasahi
//
using UnityEngine;
using System.Collections;

namespace UnityChan
{
// 必要なコンポーネントの列記
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(CapsuleCollider))]
	[RequireComponent(typeof(Rigidbody))]

	public class LocoScriptKevin : MonoBehaviour
	{

		public float animSpeed = 1.5f;				
		public float lookSmoother = 3.0f;			// a smoothing setting for camera motion
		public bool useCurves = true;					
		public float useCurvesHeight = 0.5f;		

		public float forwardSpeed = 7.0f;		
		public float backwardSpeed = 2.0f;		
		public float rotateSpeed = 2.0f;		
		private CapsuleCollider col;
		private Rigidbody rb;		
		private Vector3 velocity;		
		private float orgColHight;
		private Vector3 orgVectColCenter;
		private Animator anim;							
		private AnimatorStateInfo currentBaseState;			// base layer		
				
		static int idleState = Animator.StringToHash ("Base Layer.Idle");
		static int locoState = Animator.StringToHash ("Base Layer.Locomotion");
		
		private MultiSound sounds;
		private bool isRun;
		
		bool isStart;

        void StartGame()
        {
            isStart = true;
        }
		
		void Start ()
		{
			// Animator
			anim = GetComponent<Animator> ();			
			col = GetComponent<CapsuleCollider> ();
			rb = GetComponent<Rigidbody> ();									
			orgColHight = col.height;
			orgVectColCenter = col.center;
			sounds = GetComponent<MultiSound>();
			isRun = false;
			isStart = false;			
			Invoke ("StartGame",6f);
		}
				
		void FixedUpdate ()
		{
			if (isStart){
			float h = Input.GetAxis ("Horizontal");				
			float v = Input.GetAxis ("Vertical") * 2f;				
			if (!isRun){
				if (v > 0.99999f){
					isRun = true;
					sounds.SetRun(true);
				}
			} else {
				if (!(v < 0f) && !(v > 0f)){
					isRun = false;
					sounds.SetRun(false);
				}
			}
			if (v < 0f) v = v/2f;
			anim.SetFloat ("Speed", v);							
			anim.SetFloat ("Direction", h); 						
			anim.speed = animSpeed;								
			currentBaseState = anim.GetCurrentAnimatorStateInfo (0);	
			rb.useGravity = true;
									
			velocity = new Vector3 (0, 0, v);		
			velocity = transform.TransformDirection (velocity);			
			if (v > 0.1) {
				velocity *= forwardSpeed;		
			} else if (v < -0.1) {
				velocity *= backwardSpeed;	
			}				
			
			transform.localPosition += velocity * Time.fixedDeltaTime;
			
			transform.Rotate (0, h * rotateSpeed, 0);	
	
			if (currentBaseState.nameHash == locoState) {
				if (useCurves) {
					resetCollider ();
				}
			}
		    else if (currentBaseState.nameHash == idleState) {		
				if (useCurves) {
					resetCollider ();
				}
			}
			}
		}

		void OnGUI ()
		{
			if (isStart){
			GUI.Box (new Rect (Screen.width - 260, 160, 250, 210), "Interaction");
			GUI.Label (new Rect (Screen.width - 245, 190, 250, 30), "Up/Down Arrow : Go Forwald/Go Back");
			GUI.Label (new Rect (Screen.width - 245, 220, 250, 30), "Left/Right Arrow : Turn Left/Turn Right");
			GUI.Label (new Rect (Screen.width - 245, 250, 250, 50), "Hit Space key while Stopping : LaserPunch");
            GUI.Label(new Rect(Screen.width - 245, 300, 250, 30), "Hit Ctr key : LaserPunch");
            GUI.Label(new Rect(Screen.width - 245, 330, 250, 30), "Hit Alt key : LaserPunch");
			}
		}
		
		void resetCollider ()
		{			
			col.height = orgColHight;
			col.center = orgVectColCenter;
		}
		
		public void Win(){
			sounds.Win();
		}
		
		public void Lost(){
			sounds.Lost();
		}
	}
}