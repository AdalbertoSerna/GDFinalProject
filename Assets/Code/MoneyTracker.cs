using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MoneyTracker : MonoBehaviour
{
    // Start is called before the first frame update
    private static MoneyTracker instance;

    [SerializeField] private TextMeshProUGUI pointCounter;
    public int points = 0;

    public static MoneyTracker Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MoneyTracker>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<MoneyTracker>();
                    singletonObject.name = typeof(MoneyTracker).ToString() + " (Singleton)";
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start(){
        DontDestroyOnLoad(this.gameObject);
        UpdateUI();
    }
    public int GetPoints()
    {
        return points;
    }

    public void AddPoints(int amount)
    {
        points += amount;
        UpdateUI();
    }

    public void DeductPoints(int amount)
    {
        points -= amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        pointCounter.text = "$" + points.ToString();
    }
}

