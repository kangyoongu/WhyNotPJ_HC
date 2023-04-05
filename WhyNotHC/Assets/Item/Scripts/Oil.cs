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
        //isoil�� true�� ���� �� ä���
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
    
    
    //oil 100 �Լ�
    void oilup()
    {
        isNotUsingOil = false;
        isStopping = false;
    }
}
