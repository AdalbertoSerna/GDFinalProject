using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SingletonManager : MonoBehaviour
{
    // List of singleton script instances
    public MonoBehaviour[] singletonScripts;

    private void Awake()
    {
        // Ensure only one instance of SingletonManager exists
        if (FindObjectsOfType<SingletonManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        // Keep the SingletonManager GameObject persistent across scenes
        DontDestroyOnLoad(gameObject);

        // Ensure all singleton scripts are properly initialized
        InitializeSingletons();
    }

    private void InitializeSingletons()
    {
        foreach (MonoBehaviour singletonScript in singletonScripts)
        {
            if (singletonScript != null)
            {
                // Ensure the singleton script persists across scenes
                DontDestroyOnLoad(singletonScript.gameObject);
            }
        }
    }
}

