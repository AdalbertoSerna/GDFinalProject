using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AIBehaviorStates
{
    float idleTimer =0f;
    float waitTimer=5f;
    public IdleState(AIBehavior creatureAI) : base(creatureAI){

    }
    public override void BeginState()
    {
        creatureAI.ai.MovePlayer(new Vector3(0,0,0));
    }

    public override void UpdateState()
    {
        idleTimer += Time.deltaTime;
        if(idleTimer>=waitTimer){
            creatureAI.ChangeState(creatureAI.checkoutState);
        }
    }

  
}
