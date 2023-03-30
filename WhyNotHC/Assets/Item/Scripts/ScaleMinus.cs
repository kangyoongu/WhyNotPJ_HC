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
            this.transform.localScale -= new Vector3(.5f, .5f, .5f);
            Invoke("PlusSize", 3);
            Debug.Log("Plus");

        }
    }
    
    void PlusSize()
    {
        this.transform.localScale += new Vector3(.5f, .5f, .5f);
    }

}
