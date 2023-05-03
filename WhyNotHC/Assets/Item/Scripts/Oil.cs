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
    [SerializeField] Timer timer;
    [SerializeField] float time;
    bool isUpdate;
    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }
    void Update()
    {
        //isNotUsingOil이 true면 오일 다 채우기
        if (isNotUsingOil == true)
        {
            if (isUpdate == true)
            {
                timer.Waitsecond(time);
                isUpdate = false;
            }
            bar.fillAmount = 1;
            if(!isStopping)
                Invoke("oilup", 10);
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Oil")
        {
            isUpdate = true;
            other.gameObject.SetActive(false);
            isNotUsingOil = true;
        }
    }
    
    void oilup()
    {
        isNotUsingOil = false;
        isStopping = false;
    }
}
