using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCSpawner : MonoBehaviour
{
 
   [SerializeField] GameObject NPCPrefab;
   int NPCCount = 0;
   int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ObjectSpawning());
    }

    // Update is called once per frame
    IEnumerator ObjectSpawning(){
        while(true){

            yield return new WaitForSeconds(15);
            if(NPCCount<5){
                
                spawnNPC();
            }
            else {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("NPC");
            int count = objectsWithTag.Length;
            if (count < 5)
            {
                int diff = 5 - count; // Calculate how many NPCs to spawn
                for (int i = 0; i < diff; i++)
                {
                    spawnNPC(); // Spawn NPCs until the count reaches 5
                }
            }
            }

        }
    }
    public void spawnNPC(){

        GameObject newNPC = Instantiate(NPCPrefab, new Vector3(22,3.5f,0),Quaternion.identity);
        NPCCount++;
    }


}
