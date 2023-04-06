using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePlus : MonoBehaviour
{
  public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plus")//��� ������ Ű���
        {
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
