using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int coin;
    //coin태그에 닿으면 coin +1
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        if (other.gameObject.tag == "Coin")
        {
            coin += 1;
            
            other.gameObject.SetActive(false);
            
        }

    }
}
