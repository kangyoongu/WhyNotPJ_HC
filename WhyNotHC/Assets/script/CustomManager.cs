using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;

public class CustomManager : MonoBehaviour
{
    public MeshRenderer play;
    public TextMeshProUGUI coin;
    private int count = 6;
    public Material[] mat;
    public TextMeshProUGUI[] priceText;
    string[] engName = {"bais", "mil", "fire", "doc", "pol", "rain"};
    string[] korName = {"±âº» Çï±â", "±º¿ë Çï±â", "È­¿° Çï±â", "±¸±Þ Çï±â", "°æÂû Çï±â", "¹«Áö°³ Çï±â"};
    public GameObject[] lok;
    [SerializeField] DataManager dataManager;
    bool isbuy;
    public Dictionary<string, int> keys = new Dictionary<string, int>();
    private string json;

    private void Start()
    {
        
        if (!PlayerPrefs.HasKey($"isBuy{engName[0]}"))
        {
            PlayerPrefs.SetInt($"isBuy{engName[0]}", 1);
            for (int i = 1; i < count; i++)
            {
                PlayerPrefs.SetInt($"isBuy{engName[i]}", 0);
            }
            PlayerPrefs.SetInt("onmat", 0);
        }
        play.material = mat[PlayerPrefs.GetInt("onmat")];
        for (int i = 0; i < count; i++)
        {
            if (PlayerPrefs.GetInt($"isBuy{engName[i]}") == 1)
            {
                lok[i].SetActive(false);
                priceText[i].text = $"{korName[i]} º¸À¯";
            }
        }

        json = PlayerPrefs.GetString("data");
        dataManager.skins = JsonConvert.DeserializeObject<DataManager>(json).skins;
        Work(0, 0);
    }
    public void OnClickBas()
    {
        Work(0, 0);
    }
    public void OnClickPol()
    {
        Work(200, 4);
        if(keys["coin"] >= 200)
        {
            Social.ReportProgress(GPGSIds.achievement_4, 100.0f, (bool isSucces) => { Debug.Log("pol"); });
        }
    }
    public void OnClickMil()
    {
        Work(200, 1);
        if(keys["coin"] >= 200)
        {
            Social.ReportProgress(GPGSIds.achievement, 100.0f, (bool isSucces) => { Debug.Log("Mil"); });
        }
    }
    public void OnClickRain()
    {
        Work(400, 5);
        if(keys["coin"] >= 400)
        {
            Social.ReportProgress(GPGSIds.achievement_5, 100.0f, (bool isSucces) => { Debug.Log("Rain"); });
        }
    }
    public void OnClickFire()
    {
        Work(200, 2);
        if(keys["coin"] >= 200)
        {
            Social.ReportProgress(GPGSIds.achievement_2, 100.0f, (bool isSucces) => { Debug.Log("Fire"); });
        } 
    }
    public void OnClickDoc()
    {
        Work(200, 3);
        if(keys["coin"] >= 200)
        {
            Social.ReportProgress(GPGSIds.achievement_3, 100.0f, (bool isSucces) => { Debug.Log("Doc"); });
        }
    }
    public void Work(int price, int index)
    {

        if (PlayerPrefs.GetInt($"isBuy{engName[index]}") == 1)
        {
            play.material = mat[index];
            PlayerPrefs.SetInt("onmat", index);
        }
        else if (keys["coin"] >= price)
        {
            dataManager.skins.Add(index);
            play.material = mat[index];
            lok[index].SetActive(false);
            keys["coin"] = keys["coin"] - price;
            PlayerPrefs.SetInt($"isBuy{engName[index]}", 1);
            priceText[index].text = korName[index] + "º¸À¯";
            PlayerPrefs.SetInt("onmat", index);
            coin.text = keys["coin"].ToString();
            isbuy = true;
        }
    }
    private void OnApplicationQuit()
    {
        string data = JsonConvert.SerializeObject(dataManager);
        PlayerPrefs.SetString("data", data);
    }

}
