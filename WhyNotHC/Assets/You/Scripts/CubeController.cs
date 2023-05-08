using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeController : MonoBehaviour
{
    public ConstantForce Wind;
    public ParticleSystem windRIght;
    public ParticleSystem windLeft;
    private bool wind1 = false;
    [SerializeField] int Directioin;
    private OilManager oilManager;
    [SerializeField] GameObject player;

    public float windTime;//�ٶ��ұ��� ���
    public float windForceTime = 5;//�ٶ��Ҷ�
    private Rigidbody _rb;
    [SerializeField] float power = 0.3f;

    [SerializeField] Vector3 RwindForce;
    [SerializeField] Vector3 LwindForce;
    [SerializeField] bool isWind;

    
    void Start()
    {
        Wind = GetComponent<ConstantForce>();
        _rb = GetComponent<Rigidbody>();
        isWind = true;
        RwindForce = new Vector3(1, 0, 0);
        LwindForce = new Vector3(-1, 0, 0);
    }
    private void Awake()
    {
        oilManager = player.transform.GetComponent<OilManager>();
    }

    private void Update()
    {
        if (oilManager.bar.fillAmount <= 0f)
        {
            StopCoroutine(WindCo());
        }
    }
    public void AddPower()
    {
            RwindForce += new Vector3(power, 0, 0);
            LwindForce -= new Vector3(power, 0, 0);
            RwindForce = new Vector3(Mathf.Clamp(RwindForce.x, 0, 5), 0, 0);
            LwindForce = new Vector3(Mathf.Clamp(LwindForce.x, -5, 0), 0, 0);

            windForceTime += 0.3f;
            windForceTime = Mathf.Clamp(windForceTime, 0, 20);

            print("a");
    }

    public void windSpawn() // start button
    {
        windTime = Random.Range(10, (900 - oilManager.score) * 0.08f < 20 ? 20 : (500 - oilManager.score) * 0.08f);
        StartCoroutine(WindCo());
        windRIght.gameObject.SetActive(true);
        windLeft.gameObject.SetActive(true);
    }
    
    public void StopWind()
    {
        windRIght.gameObject.SetActive(false);
        windLeft.gameObject.SetActive(false);
    }
    IEnumerator WindCo()
    {
        while (true)
        {
            if (isWind == true)
            {
                Directioin = Random.Range(0, 2);

                yield return new WaitForSeconds(windTime);

                isWind = false;
                if (Directioin == 0)
                {
                    yield return StartCoroutine(Right());// Right Wind
                }
                else if (Directioin == 1)
                {
                    yield return StartCoroutine(Left());//Left Wind
                }

                Wind.force = Vector3.zero;
                AddPower();
            }
            yield return null;
        }
        
    }
    IEnumerator Right()
    {
        Debug.Log("Rwind");
        windRIght.Play();
        Wind.force = RwindForce;
        yield return new WaitForSeconds(windForceTime);
        windRIght.Clear();
        windTime = Random.Range(10, (900 - oilManager.score) * 0.08f < 20 ? 20 : (500 - oilManager.score) * 0.08f);
        isWind = true;
    }
    IEnumerator Left()
    {
        Debug.Log("Lwind");
        windLeft.Play();
        Wind.force = LwindForce;
        yield return new WaitForSeconds(windForceTime);
        windLeft.Clear();
        windTime = Random.Range(10, (900 - oilManager.score) * 0.08f < 20 ? 20 : (500 - oilManager.score) * 0.08f);
        isWind = true;
    }
}
