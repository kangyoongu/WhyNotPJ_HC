using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScalePlus : MonoBehaviour
{
    [SerializeField] bool isPlus = false;
    [SerializeField] Timer timer;
    [SerializeField] float time;
    bool isUpdate;
    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }
    private void Update()
    {
        
            if (isPlus == true)
            {
            if (isUpdate == true)
            {
                timer.Waitsecond(time);
                isUpdate = false;
            }
            if (timer.timer[0].fillAmount == 0 || timer.timer[1].fillAmount == 0)
                {
                    isUpdate = false;
                }
            }
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plus")//헬기 사이즈 키우기
        {
            isPlus = true;
            isUpdate = true;
            other.gameObject.SetActive(false);
            this.transform.localScale += new Vector3(.2f, .2f, .2f);
            Invoke("MinusSize", 10);
        }
        
    }
    void MinusSize()
    {
        isPlus = false;
        this.transform.localScale -= new Vector3(.2f, .2f, .2f);
    }
}
