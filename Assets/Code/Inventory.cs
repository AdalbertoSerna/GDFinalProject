using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int[] arr= {0,0,0};
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addInvetory(){
        for(int i = 0; i<arr.Length;){
            if(arr[i] == 0){
                arr[i] = 1;
                break;
            }
            else{
                Debug.Log("Inventory Full");
            }
        }
    }
}
