using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameOver : MonoBehaviour//ȭ�� �̵����
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
    public ItemSpawn[] item;
    public Transform point;
    AudioSource audioSoure;

    void Start()
    {
        audioSoure = GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("best"))
        {
            PlayerPrefs.SetInt("best", 0);//�ְ� ��ϰ�?
        }
    }
    void Update()
    {
        if(bar.fillAmount == 0)
        {
            timer += Time.deltaTime;
            if(timer >= 7)//���� ���� �Ǹ�
            {
                timer = 0;
                Time.timeScale = 0;
                back.SetActive(true);
                OilManager oil = FindObjectOfType<OilManager>();
                nows.text = "your score\n<size=150>" + playing.text + "</size>";//���?���ڵ� �ٲٱ�
                if (int.Parse(playing.text) > PlayerPrefs.GetInt("best"))
                {
                    PlayerPrefs.SetInt("best", int.Parse(playing.text));
                }
                bests.text = "best score\n<size=180>" + PlayerPrefs.GetInt("best") + "</size>";
                oil.combo = 0;
                oil.combo_text.text = "";
            }
        }
        else
        {
            timer = 0;
        }
        //if(custom[0].activeSelf == true)
        //{
        //    point.localRotation = Quaternion.Euler(-15, point.localEulerAngles.y + Time.deltaTime * 60, 0);
        //}
    }
    public void OnClickrestart()//�ٽý��� ��ư�� ������ ��
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
        oil.combo = 0;
        back.SetActive(false);
        oil.score = 0;
        gmp.position = new Vector3(0.02899998f, -1.599503f, -0.4820083f);
        GameObject[] gold = GameObject.FindGameObjectsWithTag("Coin");
        for(int i = 1; i < gold.Length; i++)
        {
            Destroy(gold[i]);
        }
        audioSoure.Play();
    }
    public void OnClickMain()//�������� ���� ��ư�� ������ ��
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
        audioSoure.Play();
    }
    public void OnCLickStart()//���ο��� ���� ������ ��
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
        audioSoure.Play();
    }
    public void OnCLickCustom()//Ŀ����â ����
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
        audioSoure.Play();
    }
    public void OnCLickCustom_out()//Ŀ����â �ݱ�
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
        audioSoure.Play();
    }
    public void OnClickSetting()//������ư ������ ��
    {
        setting.SetActive(true);
        audioSoure.Play();
    }
    public void OnClickBack()//�������� �ڷΰ��� ������ ��
    {
        setting.SetActive(false);
        audioSoure.Play();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boom")//Boom �±׿� ������
        {
            other.gameObject.SetActive(false);
            bar.fillAmount = 0;//���� ������ 0
            Debug.Log("Boom");
            back.SetActive(true);//���ӿ��� â ���?
            OilManager oil = FindObjectOfType<OilManager>();
            nows.text = "your score\n<size=150>" + playing.text + "</size>";//���?���ڵ� �ٲٱ�
            if (int.Parse(playing.text) > PlayerPrefs.GetInt("best"))
            {
                PlayerPrefs.SetInt("best", int.Parse(playing.text));
            }
            bests.text = "best score\n<size=180>" + PlayerPrefs.GetInt("best") + "</size>";
            oil.combo = 0;
            oil.combo_text.text = "";
        }

    }
    
    public void reSpawnItem()
    {
        for (int i = 0; i < item.Length; i++)
        {
            item[i].itemRespawn();
        }
        
    }
}
