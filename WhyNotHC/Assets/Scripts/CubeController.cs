using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeController : MonoBehaviour
{
    public ConstantForce Wind;


    public float windTime = 1.0f;
    public float windForceTime = 3.0f;
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
            windTime = Random.Range(1, 6);
            windForceTime = Random.Range(1, 4);

            yield return new WaitForSeconds(windTime);

            Wind.force = new Vector3(10, 0, 0);

            yield return new WaitForSeconds(windForceTime);

            Wind.force = Vector3.zero;
            _rb.velocity = Vector3.zero;
        }
    }
}
