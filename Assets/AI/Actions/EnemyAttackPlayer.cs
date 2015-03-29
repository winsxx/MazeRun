using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class EnemyAttackPlayer : RAINAction
{
	public GameControlScript control;
    public MultiSound ctrlSound;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
		control = GameObject.Find ("GameControl").GetComponent<GameControlScript> ();
        ctrlSound = GameObject.Find("unitychan_dynamic_locomotion").GetComponent<MultiSound>();        
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		control.reduceHealth (20);
        ctrlSound.EnemyAttack();
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}