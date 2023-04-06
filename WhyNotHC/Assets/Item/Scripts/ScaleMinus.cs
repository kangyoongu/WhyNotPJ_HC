using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleMinus : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Minus")
        {
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
