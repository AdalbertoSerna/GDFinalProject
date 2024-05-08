using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutState : AIBehaviorStates
{
    LineHandler lineHandler;
    Vector2 movVec;
    List<Vector2> path;
    public CheckoutState(AIBehavior creatureAI) : base(creatureAI){

    }
    public override void BeginState()
    {        if(path == null){
            path = new List<Vector2>();
        }
        
       lineHandler = LineHandler.Instance(creatureAI);
       lineHandler.AddAiToList(creatureAI.ai);
       movVec = lineHandler.getPosition(creatureAI.ai);
       creatureAI.GetMoveCommand(movVec, ref path);
    }

    public override void UpdateState()
    {
        if(path.Count == 0){
            creatureAI.ChangeState(creatureAI.lineState);
            return;
        }

        Debug.DrawLine(creatureAI.ai.transform.position,path[0]);
        for(int i = 0; i < path.Count-1; i++){
            Debug.DrawLine(path[i],path[i+1]);
        }

        //Debug.Log("Check point 3 update state right before movement left in path: "+path.Count);
        creatureAI.ai.MoveCreatureToward(path[0]); //move to the next stop on the path
        if(Vector3.Distance(creatureAI.ai.transform.position,path[0]) < creatureAI.ai.speed * Time.fixedDeltaTime){
            creatureAI.ai.transform.position = path[0]; //teleport to path point so we don't overshoot
            path.RemoveAt(0); //remove element
        }
    }

 
}
