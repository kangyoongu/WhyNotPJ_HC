using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleMinus : MonoBehaviour
{
    [SerializeField] Timer timer;
    bool issmall = false;
    [SerializeField] float time;
    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }
    private void Update()
    {
        if(issmall == true)
        {
            timer.Waitsecond(time); 
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Minus")
        {
            issmall = true;
            other.gameObject.SetActive(false);
            this.transform.localScale -= new Vector3(.2f, .2f, .2f);
            Invoke("PlusSize", 10);
        }
    }
    
    void PlusSize()
    {
        this.transform.localScale += new Vector3(.2f, .2f, .2f);
    }

}
