using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    float timer = 0;
    //public GameObject back;
    public Image bar;
    public MapMaker map;
    public Height height;
    public Text nows;
    public Text bests;
    public Text playing;
    public OilManager oil;
    public GameObject mainCanv;
    public GameObject playCanv;
    public GameObject setting;
    public Transform gmp;
    public ItemSpawn[] item;
    public Transform point;
    public TextMeshProUGUI Main_Best;
    public TextMeshProUGUI Main_this;

    public ParticleSystem bomb;
    public bool isbomb = false;

    public GameObject InGameSetting;
    private bool IsStarted = false;

    public Text main_best;

    AudioSource audioSource;
    public AudioSource boom;

    [SerializeField] Image imageSetting;
    [SerializeField] Sprite timeSetting;
    [SerializeField] Sprite image1Setting;

    [SerializeField] GameObject birdGenerator;
    public Image dark;
    float time = 0;
    bool die = false;
    public GameObject dark2;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("best"))
        {
            PlayerPrefs.SetInt("best", 0);//�ְ� ��ϰ�
        }
        Main_Best.text = PlayerPrefs.GetInt("best").ToString();
        Main_this.text = PlayerPrefs.GetInt("now").ToString();
    }
    void Update()
    {
        if(die == true)
        {
            dark2.SetActive(true);
            time += Time.deltaTime * 100;
            dark.color = new Color32(0, 0, 0, (byte)Mathf.Clamp(time, 0, 255));
            if(time >= 350)
            {
                GameOverCode();
            }
        }
        if (die == false)
        {
            if (isbomb == true)
            {
                bomb.Play();
                isbomb = false;
            }


            if (bar.fillAmount == 0)
            {
                timer += Time.deltaTime;
                if (timer >= 6)//���� ���� �Ǹ�
                {
                    die = true;
                }
            }
            else
            {
                timer = 0;
            }
        }
    }
/*    public void OnClickrestart()//�ٽý��� ��ư�� ������ ��
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
        audioSource.Play();

    }
    public void OnClickMain()//�������� ���� ��ư�� ������ ��
        //SceneManager.LoadScene("moving");
    }*/
/*    public void OnClickMain()
    {
        mainCanv.SetActive(true);
        playCanv.SetActive(false);
        back.SetActive(false);
        transform.position = new Vector3(0, -1.62f, 0.82f);
        GameObject[] g = GameObject.FindGameObjectsWithTag("maps");
        for (int i = 2; i < g.Length; i++)
        {
            Destroy(g[i]);
        }
        audioSource.Play();
        Time.timeScale = 1;
        IsStarted = false;
        InGameSetting.SetActive(false);
        imageSetting.sprite = image1Setting;
    }
    }*/
    public void OnCLickStart()//���ο��� ���� ������ ��
    {
        mainCanv.SetActive(false);
        playCanv.SetActive(true);
        birdGenerator.SetActive(true);
        //setting.SetActive(false);
        IsStarted = true;
        audioSource.Play();

        //imageSetting.sprite = timeSetting;

    }
    public void OnClickSetting()//������ư ������ ��
    {
            setting.SetActive(true);
    }
    public void OnClickBack()//�������� �ڷΰ��� ������ ��
    {     
        setting.SetActive(false);
        
        audioSource.Play();
    }
    public void OnClickResume()
    {
        InGameSetting.SetActive(false);
    }

    public void OnclickIngameSetting()
    {
        TimeController.Instance.TimeSet(0);
        InGameSetting.SetActive(true);
        audioSource.Play();
    }
    public void OnclickIngameSettingBack()
    {
        TimeController.Instance.TimeSet(1);
        InGameSetting.SetActive(false);
        audioSource.Play();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Low Building")
        {
            die = true;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boom")//Boom �±׿� ������
        {
            boom.Play();
            isbomb = true;
            other.gameObject.SetActive(false);
            bar.fillAmount = 0;//���� ������ 0
            
            Debug.Log("Boom");
            OilManager oil = FindObjectOfType<OilManager>();
            nows.text = "your score\n<size=150>" + playing.text + "</size>";//��� ���ڵ� �ٲٱ�

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
    public void GameOverCode()
    {
        /*timer = 0;
        Time.timeScale = 0;
        back.SetActive(true);
        OilManager oil = FindObjectOfType<OilManager>();
        nows.text = playing.text;//��� ���ڵ� �ٲٱ�*/

        TimeController.Instance.TimeSet(1);
        PlayerPrefs.SetInt("now", int.Parse(playing.text));
        if (int.Parse(playing.text) > PlayerPrefs.GetInt("best"))
        {
            PlayerPrefs.SetInt("best", int.Parse(playing.text));
        }
        SceneManager.LoadScene("moving");
        /*bests.text = PlayerPrefs.GetInt("best").ToString();
        Main_Best.text = PlayerPrefs.GetInt("best").ToString();
        Main_this.text = playing.text;
        oil.combo = 0;
        oil.combo_text.text = "";*/
    }
}
