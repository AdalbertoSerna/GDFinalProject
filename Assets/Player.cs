using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Stats")]
    [SerializeField] float speed = 5;
    
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
    public void MovePlayer(Vector3 direction){
        Vector3 currentVel = new Vector3(0,0,0);
        rb.velocity = currentVel + (direction * speed);
    }
    public void pickup(){
       // GetComponent<AudioSource>().Play();
        //GameObject.FindGameObjectWithTag("PointTracker").GetComponent<PointsCointer>().registerdPoints();
    }
}

