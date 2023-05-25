using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    bool isMil = false;
    bool isPol = false;
    bool isRain = false;
    bool isDoc = false;
    bool isFire = false;
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
    }
    public void OnClickBas()
    {
        Work(0, 0);
    }
    public void OnClickPol()
    {
        Work(200, 4);
        if (isPol == false)
        {
            Social.ReportProgress(GPGSIds.achievement_4, 100.0f, (bool isSucces) => { });
            isPol = true;
        }
    }
    public void OnClickMil()
    {
        Work(200, 1);
        if (isMil == false)
        {
            Social.ReportProgress(GPGSIds.achievement, 100.0f, (bool isSucces) => { });
            isMil = true;
        }
    }
    public void OnClickRain()
    {
        Work(400, 5);
        if (isRain == false)
        {
            Social.ReportProgress(GPGSIds.achievement_5, 100.0f, (bool isSucces) => { });
            isRain = true;
        }
    }
    public void OnClickFire()
    {
        Work(200, 2);
        if (isFire == false)
        {
            Social.ReportProgress(GPGSIds.achievement_2, 100.0f, (bool isSucces) => { });
            isFire = true;
        }
    }
    public void OnClickDoc()
    {
        Work(200, 3);
        if (isDoc == false)
        {
            Social.ReportProgress(GPGSIds.achievement_3, 100.0f, (bool isSucces) => { });
            isDoc = true;
        }
    }
    private void Work(int price, int index)
    {
        if (PlayerPrefs.GetInt($"isBuy{engName[index]}") == 1)
        {
            play.material = mat[index];
            PlayerPrefs.SetInt("onmat", index);
        }
        else if (PlayerPrefs.GetInt("coin") >= price)
        {
            play.material = mat[index];
            lok[index].SetActive(false);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - price);
            PlayerPrefs.SetInt($"isBuy{engName[index]}", 1);
            priceText[index].text = korName[index] + "º¸À¯";
            PlayerPrefs.SetInt("onmat", index);
            coin.text = PlayerPrefs.GetInt("coin").ToString();
        }
    }
}
