using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleMinus : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] float time = 10;
    bool isUpdate;
    bool isMinus;
    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }
    private void Update()
    {
        if (isMinus == true)
        {
            if (isUpdate == true)
            {
                timer.Waitsecond(time, 2);
                isUpdate = false;
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Minus")
        {
            isUpdate = true;
            isMinus = true;
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
