using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScalePlus : MonoBehaviour
{
    [SerializeField] Image plusTimer;
  public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plus")//헬기 사이즈 키우기
        {
            plusTimer.fillAmount -= 0.1f;
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
