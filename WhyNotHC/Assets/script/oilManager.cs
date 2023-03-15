using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class oilManager : MonoBehaviour
{
    public Image bar;
    bool landing = false;
    void Update()
    {
        if(landing == false)
            bar.fillAmount -= 0.1f * Time.deltaTime;
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
            collision.gameObject.tag = "null building";
        }
    }
}
