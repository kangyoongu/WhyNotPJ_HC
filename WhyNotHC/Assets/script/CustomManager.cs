using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomManager : MonoBehaviour
{

    public MeshRenderer play;
    public TextMeshProUGUI coin;
    private int count = 4;
    public Material[] mat;
    public TextMeshProUGUI[] priceText;
    string[] engName = { "mil", "rain", "fire", "doc"};
    string[] korName = { "���� ���", "������ ���", "ȭ�� ���", "���� ���"};
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
    public void OnClickMil()
    {
        Work(0, 0);
    }
    public void OnClickRain()
    {
        Work(200, 1);
    }
    public void OnClickFire()
    {
        Work(200, 2);
    }
    public void OnClickDoc()
    {
        Work(200, 3);
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
