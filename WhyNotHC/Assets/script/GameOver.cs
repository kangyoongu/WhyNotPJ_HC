using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    float timer = 0;
    public GameObject back;
    public Image bar;
    public MapMaker map;
    public Height height;
    public Text nows;
    public Text bests;
    public Text playing;
    public OilManager oil;
    public GameObject[] main;
    public GameObject[] play;
    public GameObject[] custom;
    public GameObject setting;
    public Transform gmp;
    public ItemSpawn item;
    public Transform point;
    void Start()
    {
        if (!PlayerPrefs.HasKey("best"))
        {
            PlayerPrefs.SetInt("best", 0);//최고 기록값
        }
    }
    void Update()
    {
        if(bar.fillAmount == 0)
        {
            timer += Time.deltaTime;
            if(timer >= 7)//게임 오버 되면
            {
                timer = 0;
                Time.timeScale = 0;
                back.SetActive(true);
                nows.text = "your score\n<size=150>" + playing.text + "</size>";//기록 글자들 바꾸기
                if (int.Parse(playing.text) > PlayerPrefs.GetInt("best"))
                {
                    PlayerPrefs.SetInt("best", int.Parse(playing.text));
                }
                bests.text = "best score\n<size=180>" + PlayerPrefs.GetInt("best") + "</size>";
            }
        }
        else
        {
            timer = 0;
        }
        if(custom[0].activeSelf == true)
        {
            point.localRotation = Quaternion.Euler(-15, point.localEulerAngles.y + Time.deltaTime * 60, 0);
        }
    }
    public void OnClickrestart()//다시시작 버튼을 눌렀을 때
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
        gmp.position = new Vector3(0.02899998f, -1.599503f, -0.4820083f);
        GameObject[] gold = GameObject.FindGameObjectsWithTag("Coin");
        for(int i = 1; i < gold.Length; i++)
        {
            Destroy(gold[i]);
        }
        
    }
    public void OnClickMain()//메인으로 가는 버튼을 눌렀을 때
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
    public void OnCLickStart()//메인에서 시작 눌렀을 때
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
    public void OnCLickCustom()//커스텀창 열기
    {
        point.localPosition = new Vector3(0, -7, 0);
        for (int i = 0; i < main.Length; i++)
        {
            main[i].SetActive(false);
        }
        for (int i = 0; i < custom.Length; i++)
        {
            custom[i].SetActive(true);
        }
    }
    public void OnCLickCustom_out()//커스텀창 닫기
    {
        point.localPosition = new Vector3(0, 0, 0);
        point.localRotation = Quaternion.Euler(0, 0, 0);
        for (int i = 0; i < main.Length; i++)
        {
            main[i].SetActive(true);
        }
        for (int i = 0; i < custom.Length; i++)
        {
            custom[i].SetActive(false);
        }
    }
    public void OnClickSetting()//설정버튼 눌렀을 때
    {
        setting.SetActive(true);
    }
    public void OnClickBack()//설정에서 뒤로가기 눌렀을 때
    {
        setting.SetActive(false);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boom")
        {
            other.gameObject.SetActive(false);
            bar.fillAmount = 0;
            Debug.Log("Boom");
            gameOver();
        }

    }
    void gameOver()
    {
        back.SetActive(true);
    }
    public void reSpawnItem()
    {
        item.itemRespawn();

    }
}
