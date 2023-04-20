using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomManager : MonoBehaviour
{

    public Material[] mat;
    public MeshRenderer play;
    public TextMeshProUGUI rain;
    public TextMeshProUGUI coin;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("rainbuy"))
        {
            PlayerPrefs.SetInt("rainbuy", 0);
            PlayerPrefs.SetInt("onmat", 0);
        }
        play.material = mat[PlayerPrefs.GetInt("onmat")];
        if (PlayerPrefs.GetInt("rainbuy") == 1)
        {
            rain.text = "무지개 헬기 보유";
        }
    }
    void Update()
    {
        
    }
    public void OnClickMil()
    {
        play.material = mat[0];
        PlayerPrefs.SetInt("onmat", 0);
    }
    public void OnClickRain()
    {
        if (PlayerPrefs.GetInt("rainbuy") == 1)
        {
            play.material = mat[1];
            PlayerPrefs.SetInt("onmat", 1);
        }
        else if (PlayerPrefs.GetInt("coin") >= 200)
        {
            play.material = mat[1];
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 200);
            PlayerPrefs.SetInt("rainbuy", 1);
            rain.text = "무지개 헬기 보유";
            PlayerPrefs.SetInt("onmat", 1);
            coin.text = "coin : " + PlayerPrefs.GetInt("coin");
        }
    }
}
