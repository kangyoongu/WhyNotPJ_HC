using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class oilManager : MonoBehaviour
{
    public Image bar;
    bool landing = false;
    public height he;
    void Update()
    {
        if(landing == false)
            bar.fillAmount -= he.y*0.0003f;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "building")
        {
            landing = true;
            bar.fillAmount += 0.3f;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "building")
        {
            landing = false;
            if (collision.gameObject.GetComponentInParent<GameObject>().name != "building")
            {
                collision.gameObject.tag = "null building";
            }
        }
    }
}
