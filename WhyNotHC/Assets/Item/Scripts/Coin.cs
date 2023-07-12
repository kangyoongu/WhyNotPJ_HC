using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    public TextMeshProUGUI coin;
    public AudioSource audioSource;
    CustomManager custom;
    private void Start()
    {
        custom = FindObjectOfType<CustomManager>();
        if (!PlayerPrefs.HasKey("coin"))
        {
            PlayerPrefs.SetInt("coin", 0);
        }
        custom.keys.Add("coin", PlayerPrefs.GetInt("coin"));
        coin.text = custom.keys["coin"].ToString();
    }
    //coin�±׿� ������ coin +1
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        if (other.gameObject.tag == "Coin")
        {
            custom.keys["coin"]++;
            coin.text = custom.keys["coin"].ToString();
            other.gameObject.SetActive(false);
            audioSource.Play();
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("coin", custom.keys["coin"]);
    }
}
