using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.GetComponent<Player>() != null)
                {
                    
                    collider.GetComponent<Player>().addMoney();
                    collider.GetComponent<Player>().removeItem();
                    Debug.Log("Item removed");
                }
            }
        }
    }
}
