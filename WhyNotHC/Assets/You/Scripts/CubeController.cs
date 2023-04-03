using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeController : MonoBehaviour
{
    public ConstantForce Wind;
    public ParticleSystem windEffects;

    public float windTime = 1.0f;//�ٶ��ұ��� ���
    public float windForceTime = 3.0f;//�ٶ��ҋ�
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
            windTime = Random.Range(1, 10);
            windForceTime = Random.Range(1, 10);

            yield return new WaitForSeconds(windTime);

            windEffects.Play();
            Wind.force = new Vector3(10, 0, 0);

            yield return new WaitForSeconds(windForceTime);
            windEffects.Stop();
            Wind.force = Vector3.zero;
            _rb.velocity = Vector3.zero;
        }
    }
}
