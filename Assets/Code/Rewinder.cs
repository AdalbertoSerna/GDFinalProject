using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewinder : MonoBehaviour
{
    [SerializeField] private float interactionRange = 1f; 
    [SerializeField] Player player;
    [SerializeField] bool full = false;
   
    public void TriggerAction()
    {
        if(full == false && !player.invetoryEmpty()){
            full = true;
            player.removeItem();
            GetComponent<AudioSource>().Play();
        }
        else{
        player.addInvetory();
        }
       
    }
    
    void Update()
    {
       
        if (IsPlayerInRange(player.transform.position) && Input.GetKeyDown(KeyCode.E))
        {
                TriggerAction();
            
        }
    }

    
    private bool IsPlayerInRange(Vector3 position)
    {
        
        float distanceToPlayer = Vector3.Distance(transform.position, position);
        return distanceToPlayer <= interactionRange;
    }
}


