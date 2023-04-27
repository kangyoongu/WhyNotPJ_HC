using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vive : MonoBehaviour
{
    OilManager oilManager;
    [SerializeField]
    Image vibrationImage;
    [SerializeField]
    Sprite vibrationStopSprite;
    [SerializeField]
    Sprite vibrationOnSprite;

    // Start is called before the first frame update
    void Start()
    {
        oilManager = FindObjectOfType<OilManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickVive() 
    { 
        if (oilManager.viveon == true) 
        {
            oilManager.viveon = false;
            vibrationImage.sprite = vibrationStopSprite;
        }
        else
        {
            oilManager.viveon = true;
            vibrationImage.sprite = vibrationOnSprite;
            Handheld.Vibrate();
        }
    }
}
