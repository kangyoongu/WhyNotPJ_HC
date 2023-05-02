using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Image timer;
    // Start is called before the first frame update
    void Start()
    {
        timer.fillAmount = 1;
        timer.gameObject.SetActive(false);
    }
    public void Waitsecond(float time)
    {
        timer.gameObject.SetActive(true);
        timer.fillAmount -= Time.deltaTime * (1 / time);
        if(timer.fillAmount <= 0)
        {
            timer.gameObject.SetActive(false);
        }
    }

}
