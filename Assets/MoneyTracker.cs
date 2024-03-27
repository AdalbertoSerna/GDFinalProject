using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MoneyTracker : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI pointCounter;
    int points = 0;

    public void moneyTracker(){
        points+=10;

        pointCounter.text = "$";
        pointCounter.text += points.ToString();
    }
}

