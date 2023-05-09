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
        if(isPlus == true)
        {
            if (isUpdate == true)
            {
                timer.Waitsecond(time);
                isUpdate = false;
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plus")//��� ������ Ű���
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
        this.transform.localScale -= new Vector3(.2f, .2f, .2f);
    }
}
