using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class oilManager : MonoBehaviour
{
    public Image bar;
    bool landing = false;
    public height he;
    public int score = 0;
    public Text sc;
    bool isNotUsingOil;
    bool isStopping = false;
    void Update()
    {
        if(landing == false)
            bar.fillAmount -= he.y*0.0003f;
        sc.text = score.ToString("0");

        if (isNotUsingOil == false)
        {
            landing = false;
        }
        else
        {
            landing = true;
            bar.fillAmount = 1;
            if (!isStopping)
                Invoke("oilup", 10);
            
            

        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "building")
        {
            Debug.Log(Vector3.Distance(transform.position, collision.transform.position));
            landing = true;
            bar.fillAmount += 0.3f;
            if (collision.transform.position.z >= -0.4)
            {
                if (Vector3.Distance(transform.position, collision.transform.position) <= 1.6f)
                {
                    score += 3;
                }
                else if (Vector3.Distance(transform.position, collision.transform.position) <= 2.5f)
                {
                    score += 2;
                }
                else
                {
                    score += 1;
                }
            }
            
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "building")
        {
            landing = false;
            if (collision.transform.position.z >= -0.4)
            {
                collision.gameObject.tag = "null building";
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Oil")
        {
            other.gameObject.SetActive(false);
            isNotUsingOil = true;
            Debug.Log("oil");
            

        }
    }
    void oilup()
    {
        isNotUsingOil = false;
        isStopping = false;
    }
    
}
