using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : AIBehaviorStates
{   Vector2 moveVec;
    List<Vector2> path;
    bool firstTime = true;
    public RandomMovement(AIBehavior creatureAI) : base(creatureAI){

    }
    public override void BeginState()
    {
        
         if(path == null){
            path = new List<Vector2>();
        }
        
    }
    
    public override void UpdateState()
    {
    
        if(firstTime){
           
            MoveRandom();
             //Debug.Log("Check point 3.5 inside of first time movRan:"+moveVec);
            creatureAI.GetMoveCommand(moveVec, ref path);
            firstTime= false;
        }
        if(path.Count == 0){
            creatureAI.ChangeState(creatureAI.idleState);
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
    public void MoveRandom(){
        int num = Random.Range(1,4);
        if(num==1){
            moveVec = (new Vector2(Random.Range(-2.25f,-1f),Random.Range(-1.23f,9f)));
        }
        else if(num == 2){
            moveVec = (new Vector2(Random.Range(-5.31f,-4.67f),Random.Range(-1.23f,9f)));
        }
        else if(num == 3){
            moveVec = (new Vector2(Random.Range(-11.6f,-10.62f),Random.Range(-1.23f,9f)));
        }
        else if(num == 4){
            moveVec = (new Vector2(Random.Range(-14.3f,-13.63f),Random.Range(-1.23f,9f)));
        }


    }
    //use this to choose where we need to go and use the path finding a* to move their smoothly
    // Start is called before the first frame update
}
