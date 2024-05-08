using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Stats")]
    [SerializeField] public float speed = 5;
    [SerializeField] public int money = 0;
    
    int[] arr = {0,0,0};
    
    Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
    }
    public void MovePlayer(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * speed;
    }
   // public void pickup(){
       // GetComponent<AudioSource>().Play();
        //GameObject.FindGameObjectWithTag("PointTracker").GetComponent<PointsCointer>().registerdPoints();
   // }
    public void addInvetory(){
        for(int i = 0; i<arr.Length;i++){
            if(arr[i] == 0){
                arr[i] = 1;
                Debug.Log("Add to inventory");
                break;
            }
            else{
                Debug.Log("Inventory Full");
                
            }
        }
    }
    public bool invetoryEmpty(){
        Debug.Log(arr[0]);
        if (arr[0] != 0 || arr[1] != 0 || arr[2] != 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void removeItem(){
         if(!invetoryEmpty()){
         arr[0] = arr[1];
         arr[1] = arr[2];
         arr[2] = 0;   
         } 
    }
    public void addMoney(){
        if(!invetoryEmpty()){
        int money = 10;
        if(PlayerPrefs.HasKey("Candy")){
            money+=10;
        }
        if(PlayerPrefs.HasKey("Popcorn")){
            money+=5;
        }
        if(PlayerPrefs.HasKey("DVD")){
            money+=10;
        }
        if(PlayerPrefs.HasKey("Bluray")){
            money+=20;
        }
        GameObject.FindGameObjectWithTag("MoneyTracker").GetComponent<MoneyTracker>().AddPoints(money);
        }
    }
    public void MoveCreatureToward(Vector3 target)
    {
        Vector3 direction = target - transform.position;
        //Debug.Log(direction);
        MovePlayer(direction.normalized);
    }
    public void MoveLine(Vector3 target, System.Action value)
    {
        Vector3 direction = target - transform.position;
        //Debug.Log(direction);
        MovePlayer(direction.normalized);
    }
}

