using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    float timer = 0;
    public GameObject back;
    public Image bar;
    public mapMaker map;
    public height height;
    public Text nows;
    public Text bests;
    public oilManager oil;
    public GameObject[] main;
    public GameObject[] play;
    public GameObject setting;
    void Start()
    {
        
    }
    void Update()
    {
        if(bar.fillAmount == 0)
        {
            timer += Time.deltaTime;
            if(timer >= 7)
            {
                timer = 0;
                Time.timeScale = 0;
                back.SetActive(true);
            }
        }
        else
        {
            timer = 0;
        }
    }
    public void OnClickrestart()
    {
        transform.position = new Vector3(0, -1.62f, 0.82f);
        GameObject[] g = GameObject.FindGameObjectsWithTag("maps");
        for(int i = 2; i < g.Length; i++)
        {
            Destroy(g[i]);
        }
        map.z = -3;
        map.l = -75;
        bar.fillAmount = 1;
        Time.timeScale = 1;
        back.SetActive(false);
        oil.score = 0;
    }
    public void OnClickMain()
    {
        for(int i = 0; i < main.Length; i++)
        {
            main[i].SetActive(true);
        }
        for (int i = 0; i < play.Length; i++)
        {
            play[i].SetActive(false);
        }
        back.SetActive(false);
        transform.position = new Vector3(0, -1.62f, 0.82f);
        GameObject[] g = GameObject.FindGameObjectsWithTag("maps");
        for (int i = 2; i < g.Length; i++)
        {
            Destroy(g[i]);
        }
    }
    public void OnCLickStart()
    {
        for (int i = 0; i < main.Length; i++)
        {
            main[i].SetActive(false);
        }
        for (int i = 0; i < play.Length; i++)
        {
            play[i].SetActive(true);
        }
        setting.SetActive(false);
        OnClickrestart();
    }
    public void OnClickSetting()
    {
        setting.SetActive(true);
    }
    public void OnClickBack()
    {
        setting.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boom")
        {
            other.gameObject.SetActive(false);
            bar.fillAmount = 0;
        }

    }
}
