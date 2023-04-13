using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    public TextMeshProUGUI coin;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("coin"))
        {
            PlayerPrefs.SetInt("coin", 0);
        }
    }
    //coin�±׿� ������ coin +1
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        if (other.gameObject.tag == "Coin")
        {
            
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 1);
            coin.text = ":" + PlayerPrefs.GetInt("coin");
            other.gameObject.SetActive(false);
            
        }

    }
}
