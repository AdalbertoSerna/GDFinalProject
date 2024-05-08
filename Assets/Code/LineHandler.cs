using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineHandler//:MonoBehaviour
{
    // Start is called before the first frame update
    private static LineHandler instance = null;
    WaitingQueue wq; 
    AIBehavior ai;
    List<Vector2> waitingList;
//       public void Start(){
  //  DontDestroyOnLoad(this);
   //}
    private LineHandler(AIBehavior ai)
    {  
        this.ai = ai;
        waitingList = new List<Vector2>();
         Vector2 firstPosition = new Vector3(14,-1.5f);
        // float positionSize = 2f;
         for(int i = 0; i<5; i++){
            waitingList.Add(firstPosition+ new Vector2(0,1)*1.5f*i);
            Debug.Log("wait at :"+i+waitingList[i]);
         }
        wq = WaitingQueue.Instance(waitingList,ai);
    }

    public static LineHandler Instance(AIBehavior ai)
    {

            if (instance == null)
            {
                instance = new LineHandler(ai);
            }
            return instance;
        
    }
        public static LineHandler Instance()
    {
            return instance;
        
    }

    public void AddAiToList(Player ai){
       if(ai == null){
        Debug.Log("Crap");
       }
        wq.AddGuest(ai);
        
    }

    public Vector2 getPosition(Player ai){
            int i = wq.getPosition(ai);
            return waitingList[i];
    }
    public void RemovePosition(Player ai){
        wq.RemoveFromLine(ai);
    }
}
