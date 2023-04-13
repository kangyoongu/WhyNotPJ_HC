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
    public float windForceTime = 5;//바람불떄
    private Rigidbody _rb;

    private Vector3 RwindForce = new Vector3(2, 0, 0);
    private Vector3 LwindForce = new Vector3(-2, 0, 0);
    void Start()
    {
        Wind = GetComponent<ConstantForce>();
        _rb = GetComponent<Rigidbody>();
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


        //if(wind1 == true && oilManager.score % 50 != 0)
        //{
        //    wind1 = false;
        //}

    }

    public void AddPower()
    {
            RwindForce += new Vector3(0.3f, 0, 0);
            LwindForce += new Vector3(-0.3f, 0, 0);
            windForceTime += 0.3f;
            print("a");
    }

    //private void windPlus()
    //{
    //    wind1 = true;
    //    RwindForce += new Vector3(0.3f, 0, 0);
    //    LwindForce += new Vector3(-0.3f, 0, 0);
    //    windForceTime += 0.3f;
    //    print("a");
    //}
    public void windSpawn()
    {
        StartCoroutine(WindCo());
    }




    IEnumerator WindCo()
    {
        while (true)
        {
            windTime = Random.Range(10, (900 - oilManager.score) * 0.08f < 20 ? 20 : (500 - oilManager.score) * 0.08f);
           
            Directioin = Random.Range(0, 2);
            
            yield return new WaitForSeconds(windTime);
            
            if (Directioin == 0)
            {
                
                windRIght.Play();
                Wind.force = RwindForce;
                yield return new WaitForSeconds(windForceTime);
                windRIght.Stop();
            }
            else
            {
              
                windLeft.Play();
                Wind.force = LwindForce;
                yield return new WaitForSeconds(windForceTime);
                windLeft.Stop();
            }
            Wind.force = Vector3.zero;
            //_rb.velocity = Vector3.zero;
        }
    }
}
