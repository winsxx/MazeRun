using UnityEngine;
using System.Collections;

namespace UnityChan
{
//
// ↑↓キーでループアニメーションを切り替えるスクリプト（ランダム切り替え付き）Ver.3
// 2014/04/03 N.Kobayashi
//

// Require these components when using this script
	[RequireComponent(typeof(Animator))]



	public class LaserPunchScriptKevin : MonoBehaviour
	{
	
		private Animator anim;						
		private AnimatorStateInfo currentState;		
		private AnimatorStateInfo previousState;	
		public bool _random = false;				

		// Use this for initialization
		void Start ()
		{			
			anim = GetComponent<Animator> ();
			currentState = anim.GetCurrentAnimatorStateInfo (0);
			previousState = currentState;
		}
	
		// Update is called once per frame
		void  Update ()
		{			
			if (Input.GetButton ("Jump")) {				
				anim.SetBool ("LaserPunch", true);
			}		
					
			if (anim.GetBool ("LaserPunch")) {				
				currentState = anim.GetCurrentAnimatorStateInfo (0);
				if (previousState.nameHash != currentState.nameHash) {
					anim.SetBool ("LaserPunch", false);
					previousState = currentState;				
				}
			}
		}
	}
}
