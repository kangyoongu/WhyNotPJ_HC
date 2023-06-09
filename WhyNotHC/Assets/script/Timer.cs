using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image[] timer;
    bool isTimerOn = false;
    public Image[] itemImage;
    public Sprite[] itemImages;

    void Start()
    {
        timer[0].fillAmount = 0;
        timer[1].fillAmount = 0;
        itemImage[0].gameObject.SetActive(false);
        itemImage[1].gameObject.SetActive(false);
    }
    public void Waitsecond(float time, int imageNum)
    {
        int i;
        if (isTimerOn)
            i = 1;
        else
            i = 0;
        
        timer[i].gameObject.SetActive(true);
        itemImage[i].gameObject.SetActive(true);
        itemImage[i].sprite = itemImages[imageNum];
        StartCoroutine(Del(time, i));
        
    }

    IEnumerator Del(float time ,int i)
    {
        if(i == 0)
        {
            isTimerOn = true;
        }
        timer[i].fillAmount = 1;
        while (true)
        {
            timer[i].fillAmount -= Time.deltaTime * (1 / time);
                if (timer[i].fillAmount <= 0)
                {
                itemImage[i].gameObject.SetActive(false);
                if (i == 0)
                    {
                        isTimerOn = false;
                    }
                    break;
                }
            yield return null;
        }
    }
}
