using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingQueue //:MonoBehaviour
{
    List<Player> lineList = new List<Player>();
    List<Vector2> positionList = new List<Vector2>();
    Vector3 entrancePosition;
    AIBehavior creatureAI;
   private static WaitingQueue instance;
  // public void Start(){
    //DontDestroyOnLoad(this);
   //}
    private WaitingQueue(List<Vector2> positionList, AIBehavior creatureAI){
        this.creatureAI=creatureAI;
        this.positionList = positionList;
        entrancePosition = positionList[positionList.Count - 1];
    }
    public static WaitingQueue Instance(List<Vector2> positionList,AIBehavior ai)
    {

            if (instance == null)
            {
                instance = new WaitingQueue(positionList,ai);        
               
                 
            }
            return instance;
        
    }
    public void AddGuest(Player ai){
        List<Vector2> path = new List<Vector2>();
        lineList.Add(ai);
    }
    public int getPosition(Player ai){
            return lineList.IndexOf(ai);
    }
    public void getlist(){
        Debug.Log(entrancePosition);
    }
    public void RemoveFromLine(Player ai){
        lineList.RemoveAt(lineList.IndexOf(ai));
    }
}
