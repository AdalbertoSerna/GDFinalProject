using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopButton : MonoBehaviour
{
    int itemNumber;
    int itemPrice;
    [SerializeField] Canvas canvas;
    [SerializeField] private TextMeshProUGUI pointCounter;
    MoneyTracker mt;
    // Start is called before the first frame updat

    public void Start(){
        mt = MoneyTracker.Instance;
        UpdateUI();
        Debug.Log(mt.GetPoints());
    }
    public void BuyCandy(){
        itemNumber = 1;
        itemPrice = 100;
        int money = mt.GetPoints();
        if(money < itemPrice || mt == null){
            OpenMenu();
        }
        else{
            mt.DeductPoints(itemPrice);
        PlayerPrefs.SetInt("Candy", 1);
        PlayerPrefs.Save();
        PlayAudio();
        UpdateUI();
        }

    }
    public void BuyPopcorn(){
        itemNumber = 2;
        itemPrice = 50;
        int money = mt.GetPoints();
        if(money < itemPrice || mt == null){
            OpenMenu();
        }
        else{
            mt.DeductPoints(itemPrice);
        PlayerPrefs.SetInt("Popcorn", 1);
        PlayerPrefs.Save();
        PlayAudio();
        UpdateUI();
        }
    }
    public void BuyDVD(){
        itemNumber = 3;
        itemPrice = 100;
        int money = mt.GetPoints();
        if(money < itemPrice || mt == null){
            OpenMenu();
        }
        else{
            mt.DeductPoints(itemPrice);
        PlayerPrefs.SetInt("DVD", 1);
        PlayerPrefs.Save();
        PlayAudio();
        UpdateUI();
        }
    }
    public void BuyBluray(){
        itemNumber = 4;
        itemPrice = 300;
        int money = mt.GetPoints();
        if(money < itemPrice || mt == null){
            OpenMenu();
        }
        else{
            mt.DeductPoints(itemPrice);
        PlayerPrefs.SetInt("Bluray", 1);
        PlayerPrefs.Save();
        PlayAudio();
        UpdateUI();
        }
    }
    
    public void OpenMenu(){
        canvas.enabled=true;
    }
    public void CloseMenu(){
        canvas.enabled=false;
    }
    public void SceneChanger(){
        SceneManager.LoadScene("MainLoop");
    }
    private void UpdateUI()
    {
        pointCounter.text = "$" + mt.GetPoints().ToString();
    }
    public void PlayAudio(){
        GetComponent<AudioSource>().Play();
    }
}
