using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeKeeper : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI timeText;

    private string[] times = { "10:00 AM", "10:30 AM", "11:00 AM", "11:30 AM", "12:00 PM",
                               "12:30 PM", "01:00 PM", "01:30 PM", "02:00 PM", "02:30 PM",
                               "03:00 PM", "03:30 PM", "04:00 PM", "04:30 PM", "05:00 PM",
                               "05:30 PM", "06:00 PM", "06:30 PM", "07:00 PM", "07:30 PM",
                               "08:00 PM" };
    private int currentIndex = 0;

    private void Start()
    {
        UpdateClock();
        StartCoroutine(UpdateTime());
    }

    private IEnumerator UpdateTime()
    {
        while (currentIndex < times.Length)
        {
            yield return new WaitForSeconds(15); // Update time every 30 seconds
            UpdateClock();
        }
    }

    private void UpdateClock()
    {
        timeText.text = times[currentIndex];
        if(times[currentIndex]=="06:00 PM"){
             SceneManager.LoadScene("Shop");
        }
        currentIndex++;
        
    }
}