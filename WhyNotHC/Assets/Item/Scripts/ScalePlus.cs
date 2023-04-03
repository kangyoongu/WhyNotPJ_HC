using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePlus : MonoBehaviour
{
  public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plus")//헬기 사이즈 키우기
        {
            other.gameObject.SetActive(false);
            this.transform.localScale += new Vector3(.2f, .2f, .2f);
            Invoke("MinusSize", 10);
            Debug.Log("Minus");
            
        }
        
    }
    void MinusSize()
    {
        this.transform.localScale -= new Vector3(.2f, .2f, .2f);
    }
}
