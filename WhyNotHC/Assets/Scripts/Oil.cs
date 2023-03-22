using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Oil : MonoBehaviour
{
    
    [SerializeField] float oil;
    bool isNotUsingOil;
    bool isStopping = false;

    
    void Start()
    {
    
        oil = 100f;
    }

    
    void Update()
    {
        //isoil이 false면 oil양 감소
        if (isNotUsingOil == false)
        {
            oil -= 0.1f;
        }
        else
        {
            oil = 100;
            if(!isStopping)
                Invoke("oilup", 3);
            //if (oilper == true)
            //{

            //    isoil = false;

            //}

        }
        

    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Oil")
        {
            other.gameObject.SetActive(false);
            isNotUsingOil = true;
            //oilper = true;
        }
    }
    
    //oil 100 코루틴
    

    //oil 100 함수
    void oilup()
    {
        isNotUsingOil = false;
        isStopping = false;
    }
}
