using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vive : MonoBehaviour
{
    OilManager oilManager;
    // Start is called before the first frame update
    void Start()
    {
        oilManager = GetComponent<OilManager>();
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
        }
        else
        {
            oilManager.viveon = true;
            Handheld.Vibrate();
        }
    }
}
