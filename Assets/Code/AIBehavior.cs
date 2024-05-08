using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aoiti.Pathfinding;
public class AIBehavior : MonoBehaviour
{

   public Player ai;
   AIBehaviorStates currentState;
    public IdleState idleState{get; private set;}
    public RandomMovement randomState{get; private set;}
    public CheckoutState checkoutState{get; private set;} 
    public LineState lineState{get; private set;}
    public ExitState exitState{get; private set;}

    [Header("Config")]
    [SerializeField] LayerMask obstacles;
    //public float sightDistance = 5;

    [Header("Pathfinding")]
    Pathfinder<Vector2> pathfinder;
    [SerializeField] float gridSize = 1f;
    public void ChangeState(AIBehaviorStates newState){

        currentState = newState;

        currentState.BeginStateBase();
    }   
    void Start()
    {
        idleState = new IdleState(this);
        randomState = new RandomMovement(this);
        checkoutState = new CheckoutState(this);
        lineState = new LineState(this);
        exitState = new ExitState(this);
        currentState = randomState;
        pathfinder = new Pathfinder<Vector2>(GetDistance,GetNeighbourNodes,1000);
        currentState.BeginStateBase();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        currentState.UpdateStateBase();
    }
    public void GetMoveCommand(Vector2 target, ref List<Vector2> path)
    {
        path.Clear();
        Vector2 closestNode = GetClosestNode(ai.transform.position);
        if (pathfinder.GenerateAstarPath(closestNode, GetClosestNode(target), out path)) //Generate path between two points on grid that are close to the transform position and the assigned target.
        {
            path.Add(target); //add the final position as our last stop
        }
    }

    Vector2 GetClosestNode(Vector2 target) 
    {
        return new Vector2(Mathf.Round(target.x/gridSize)*gridSize, Mathf.Round(target.y / gridSize) * gridSize);
    }


    float GetDistance(Vector2 A, Vector2 B) 
    {
        return (A - B).sqrMagnitude; //Uses square magnitude to lessen the CPU time.
    }


    Dictionary<Vector2,float> GetNeighbourNodes(Vector2 pos) 
    {
        Dictionary<Vector2, float> neighbours = new Dictionary<Vector2, float>();
        float buffer = .5f;
        for (int i=-1;i<2;i++)
        {
            for (int j=-1;j<2;j++)
            {
                if (i == 0 && j == 0) continue;

                Vector2 dir = new Vector2(i, j)*gridSize;
                if (!Physics2D.Linecast(pos,pos+dir, obstacles))
                {
                    if(!WithinBufferZone(pos,buffer))
                    neighbours.Add(GetClosestNode( pos + dir), dir.magnitude);
                }
            }

        }
        return neighbours;
    }

    
    List<Vector2> ShortenPath(List<Vector2> path)
    {
        List<Vector2> newPath = new List<Vector2>();
        
        for (int i=0;i<path.Count;i++)
        {
            newPath.Add(path[i]);
            for (int j=path.Count-1;j>i;j-- )
            {
                if (!Physics2D.Linecast(path[i],path[j], obstacles))
                {
                    
                    i = j;
                    break;
                }
            }
            newPath.Add(path[i]);
        }
        newPath.Add(path[path.Count - 1]);
        return newPath;
    }

    bool WithinBufferZone(Vector2 pos, float bufferDistance){
    Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, bufferDistance, obstacles);
    return colliders.Length > 0; // If any colliders are found within the buffer zone, return true
    }

    public void destroyNPC(){
        Destroy(gameObject);
    }

}
