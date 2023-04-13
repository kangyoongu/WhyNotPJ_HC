using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cradit : MonoBehaviour
{
    public GameObject back;
    void Update()
    {
        
    }
    public void OnClickCra()
    {
        back.SetActive(true);
    }
    public void OnClickBack()
    { back.SetActive(false); 
    }
}
