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
    string[] korName = {"�⺻ ���", "���� ���", "ȭ�� ���", "���� ���", "���� ���", "������ ���"};
    public GameObject[] lok;
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
                priceText[i].text = $"{korName[i]} ����";
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
        if(PlayerPrefs.GetInt("coin") >= 200)
            Social.ReportProgress(GPGSIds.achievement_4, 100.0f, (bool isSucces) => { });
    }
    public void OnClickMil()
    {
        Work(200, 1);
        if(PlayerPrefs.GetInt("coin") >= 200)
            Social.ReportProgress(GPGSIds.achievement, 100.0f, (bool isSucces) => { });
    }
    public void OnClickRain()
    {
        Work(400, 5);
        if(PlayerPrefs.GetInt("coin") >= 400)
            Social.ReportProgress(GPGSIds.achievement_5, 100.0f, (bool isSucces) => { });
    }
    public void OnClickFire()
    {
        Work(200, 2);
        if(PlayerPrefs.GetInt("coin") >= 200)
            Social.ReportProgress(GPGSIds.achievement_2, 100.0f, (bool isSucces) => { });
    }
    public void OnClickDoc()
    {
        Work(200, 3);
        if(PlayerPrefs.GetInt("coin") >= 200)
            Social.ReportProgress(GPGSIds.achievement_3, 100.0f, (bool isSucces) => { });
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
            priceText[index].text = korName[index] + "����";
            PlayerPrefs.SetInt("onmat", index);
            coin.text = PlayerPrefs.GetInt("coin").ToString();
        }
    }
}
