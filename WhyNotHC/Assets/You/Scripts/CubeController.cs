using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeController : MonoBehaviour
{
    public ConstantForce Wind;
    public ParticleSystem windRIght;
    public ParticleSystem windLeft;
    private bool wind1 = false;
    int Directioin;
    private OilManager oilManager;
    [SerializeField] GameObject player;

    public float windTime;//바람불기전 대기
    public float windForceTime = 5;//바람불때
    private Rigidbody _rb;
    [SerializeField] float power = 0.3f;

    [SerializeField] Vector3 RwindForce;
    [SerializeField] Vector3 LwindForce;
    [SerializeField] bool isWind;
    void Start()
    {
        Wind = GetComponent<ConstantForce>();
        _rb = GetComponent<Rigidbody>();
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
            RwindForce += new Vector3(Mathf.Clamp(power, 0, 5), 0, 0);
            LwindForce += new Vector3(-(Mathf.Clamp(power, 0, 5)), 0, 0);
            windForceTime += 0.3f;
            windForceTime = Mathf.Clamp(windForceTime, 0, 20);
        print("a");
    }
    public void windSpawn()
    {
        StartCoroutine(WindCo());
    }
    IEnumerator WindCo()
    {
        while (true)
        {
            if (isWind == true)
            {
                windTime = Random.Range(10, (900 - oilManager.score) * 0.08f < 20 ? 20 : (500 - oilManager.score) * 0.08f);
            
                Directioin = Random.Range(0, 2);
                

            yield return new WaitForSeconds(windTime);

            if(Directioin == 0)
            {
                StartCoroutine(Right());
            }
            else if(Directioin == 1)
            {
                StartCoroutine(Left());
            }

            Wind.force = Vector3.zero;
            AddPower();
            isWind = false;
            }
            yield return null;
        }
        
    }
    IEnumerator Right()
    {
        windRIght.Play();
        Wind.force = RwindForce;
        yield return new WaitForSeconds(windForceTime);
        windRIght.Stop();
        isWind = true;
    }
    IEnumerator Left()
    {
        windLeft.Play();
        Wind.force = LwindForce;
        yield return new WaitForSeconds(windForceTime);
        windLeft.Stop();
        isWind = true;
    }
}
