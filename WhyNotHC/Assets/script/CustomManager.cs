using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomManager : MonoBehaviour
{
    public Material[] mat;
    public MeshRenderer play;
    public TextMeshProUGUI mil;
    public TextMeshProUGUI rain;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("rainbuy"))
        {
            PlayerPrefs.SetInt("milbuy", 0);
            PlayerPrefs.SetInt("rainbuy", 0);
        }
        if (PlayerPrefs.GetInt("rainbuy") == 1)
        {
            mil.text = "군용 헬기 보유";
            rain.text = "무지개 헬기 보유";
        }
    }
    void Update()
    {
        
    }
    public void OnClickMil()
    {
        if (PlayerPrefs.GetInt("coin") >= 100)
        {
            play.material = mat[0];
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 100);
            PlayerPrefs.SetInt("milbuy", 1);
            mil.text = "군용 헬기 보유";
        }
        if (PlayerPrefs.GetInt("milbuy") == 1)
        {
            play.material = mat[0];
        }
    }
    public void OnClickRain()
    {
        if (PlayerPrefs.GetInt("coin") >= 200)
        {
            play.material = mat[1];
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 200);
            PlayerPrefs.SetInt("rainbuy", 1);
            rain.text = "무지개 헬기 보유";
        }
        if (PlayerPrefs.GetInt("rainbuy") == 1)
        {
            play.material = mat[1];
        }
    }
}
