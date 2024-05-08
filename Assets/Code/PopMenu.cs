using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Canvas canvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenMenu(){
        canvas.enabled=true;
    }
    public void CloseMenu(){
        canvas.enabled=false;
    }
}
