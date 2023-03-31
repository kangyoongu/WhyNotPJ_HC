using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePlus : MonoBehaviour
{
  public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plus")
        {
            other.gameObject.SetActive(false);
            this.transform.localScale += new Vector3(.3f, .3f, .3f);
            Invoke("MinusSize", 3);
            Debug.Log("Minus");
            
        }
        
    }
    void MinusSize()
    {
        this.transform.localScale -= new Vector3(.3f, .3f, .3f);
    }
}
