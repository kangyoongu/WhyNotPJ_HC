using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeController : MonoBehaviour
{
    public ConstantForce Wind;
    public ParticleSystem windRIght;
    public ParticleSystem windLeft;

    float Directioin;

    public float windTime;//바람불기전 대기
    public float windForceTime;//바람불떄
    private Rigidbody _rb;
    void Start()
    {
        Wind = GetComponent<ConstantForce>();
        _rb = GetComponent<Rigidbody>();
        StartCoroutine(WindCo());
    }

    


    IEnumerator WindCo()
    {
        while (true)
        {
            windTime = Random.Range(10, 20);
            windForceTime = Random.Range(3,6);
            Directioin = Random.Range(0, 2);

            yield return new WaitForSeconds(windTime);
            if(Directioin == 0)
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
