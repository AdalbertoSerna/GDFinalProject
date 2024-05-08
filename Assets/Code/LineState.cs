using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineState : AIBehaviorStates
{
    Player player;
    LineHandler lh;
    Vector2 movVec;
    List<Vector2> path;
    public LineState(AIBehavior creatureAI) : base(creatureAI)
    {
    }

    public override void BeginState()
    {
       lh= LineHandler.Instance();
         GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            // Get the Player component from the player object
            player = playerObject.GetComponent<Player>();
        } 
        if(path == null){
            path = new List<Vector2>();
        }      
    }

    public override void UpdateState()
    {
        if(Input.GetKeyUp(KeyCode.E) && IsWithinDistance()){
            player.GetComponent<AudioSource>().Play();
            player.addInvetory();
            lh.RemovePosition(creatureAI.ai);
            creatureAI.ChangeState(creatureAI.exitState);
        }
        else{
        movVec = lh.getPosition(creatureAI.ai);
        creatureAI.GetMoveCommand(movVec, ref path);

        //Debug.Log("Check point 3 update state right before movement left in path: "+path.Count);
        creatureAI.ai.MoveCreatureToward(path[0]); //move to the next stop on the path
        if(Vector3.Distance(creatureAI.ai.transform.position,path[0]) < creatureAI.ai.speed * Time.fixedDeltaTime){
            creatureAI.ai.transform.position = path[0]; //teleport to path point so we don't overshoot
            path.RemoveAt(0); //remove element
        }
        
        }
    }

    public bool IsWithinDistance(){
        float distanceToPlayer = Vector3.Distance(creatureAI.ai.transform.position, player.transform.position);
        
        return distanceToPlayer <= 3f;
    }
    
}
