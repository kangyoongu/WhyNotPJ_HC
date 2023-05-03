using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleMinus : MonoBehaviour
{
    [SerializeField] Timer timer;
    bool issmall = false;
    [SerializeField] float time;
    bool isUpdate;
    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }
    private void Update()
    {
        
            if (issmall == true)
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
        if (other.gameObject.tag == "Minus")
        {
            issmall = true;
            isUpdate = true;
            other.gameObject.SetActive(false);
            this.transform.localScale -= new Vector3(.2f, .2f, .2f);
            Invoke("PlusSize", 10);
        }
    }
    
    void PlusSize()
    {
        issmall = false;
        this.transform.localScale += new Vector3(.2f, .2f, .2f);
    }

}
