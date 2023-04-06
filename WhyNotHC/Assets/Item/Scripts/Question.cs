using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{

    public Move1 move;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Quest")
        {
            move.isQuest = true;
            other.gameObject.SetActive(false);
        }
    }
}