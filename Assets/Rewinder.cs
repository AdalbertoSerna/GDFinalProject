using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewinder : MonoBehaviour
{
    [SerializeField] private float interactionRange = 2f; 
    [SerializeField] Player player;
   
    public void TriggerAction()
    {
        Debug.Log("Button pressed! Triggering action...");
       
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


