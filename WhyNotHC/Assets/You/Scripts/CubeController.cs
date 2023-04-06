using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeController : MonoBehaviour
{
    public ConstantForce Wind;
    public ParticleSystem windRIght;
    public ParticleSystem windLeft;

    float Directioin;

    private OilManager oilManager;
    [SerializeField] GameObject player;

    public float windTime;//�ٶ��ұ��� ���
    public float windForceTime;//�ٶ��ҋ�
    private Rigidbody _rb;
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
    }
    public void windSpawn()
    {
        StartCoroutine(WindCo());
    }




    IEnumerator WindCo()
    {
        while (true)
        {
            windTime = Random.Range(10, (500 - oilManager.score) * 0.2f < 20 ? 20 : (500 - oilManager.score) * 0.2f);
            windForceTime = Random.Range(3, 5);
            Directioin = Random.Range(0, 2);

            yield return new WaitForSeconds(windTime);
            if (Directioin == 0)
            {
                windRIght.Play();
                Wind.force = new Vector3(3, 0, 0);
                yield return new WaitForSeconds(windForceTime);
                windRIght.Stop();
            }
            else
            {
                windLeft.Play();
                Wind.force = new Vector3(-3, 0, 0);
                yield return new WaitForSeconds(windForceTime);
                windLeft.Stop();
            }
            Wind.force = Vector3.zero;
            //_rb.velocity = Vector3.zero;
        }
    }
}
