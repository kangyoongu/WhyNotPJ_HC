using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Oil : MonoBehaviour
{
    
    
    bool isNotUsingOil;
    bool isStopping = false;
    public Image bar;

    
    void Start()
    {
    
        
    }

    
    void Update()
    {
        //isoil이 false면 oil양 감소
        if (isNotUsingOil == false)
        {
            
        }
        else
        {
            
            bar.fillAmount = 1;
            if(!isStopping)
                Invoke("oilup", 3);
            
            

        }
        

    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Oil")
        {
            other.gameObject.SetActive(false);
            isNotUsingOil = true;
            

        }
    }
    
    
    //oil 100 함수
    void oilup()
    {
        isNotUsingOil = false;
        isStopping = false;
    }
}
