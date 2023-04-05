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

    

    void Update()
    {
        //isoil이 true면 오일 다 채우기
        if (isNotUsingOil == true)
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
