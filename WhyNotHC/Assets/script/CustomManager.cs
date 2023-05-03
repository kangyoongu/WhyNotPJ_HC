using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomManager : MonoBehaviour
{

    public MeshRenderer play;
    public TextMeshProUGUI coin;
    private int count = 2;
    public Material[] mat;
    public TextMeshProUGUI[] priceText;
    string[] engName = { "mil", "rain" };
    string[] korName = { "군용 헬기", "무지개 헬기" };
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
        //for (int i = 0; i < count; i++)
        //{
        //    if (PlayerPrefs.GetInt($"isBuy{engName[i]}") == 1)
        //    {
        //        priceText[i].text = $"{korName} 보유";
        //    }
        //}
    }
    void Update()
    {
        
    }
    public void OnClickMil()
    {
        Work(0, 1);
    }
    public void OnClickRain()
    {
        Work(200, 1);
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
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - price);
            PlayerPrefs.SetInt($"isBuy{engName[index]}", 1);
            priceText[index].text = korName[index] + "보유";
            PlayerPrefs.SetInt("onmat", index);
            coin.text = PlayerPrefs.GetInt("coin").ToString();
        }
    }
}
