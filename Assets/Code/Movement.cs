using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Player player;

    
    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(0,0,0);
        if(Input.GetKey(KeyCode.A)){
            input.x += -1;
        }
        if(Input.GetKey(KeyCode.D)){
            input.x += 1;
        }
        if(Input.GetKey(KeyCode.S)){
            input.y += -1;
        }
        if(Input.GetKey(KeyCode.W)){
            input.y += 1;
        }
        
        player.MovePlayer(input);
    }
}
