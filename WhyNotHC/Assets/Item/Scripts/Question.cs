using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{

    public Move1 move;
    
    Plane plane;

    private void Awake()
    {
        //move = FindObjectOfType<Move1>();
        //plane.SetNormalAndPosition(Camera.main.transform.forward * -1, Camera.main.transform.position + Camera.main.transform.forward * 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌");
        if(other.gameObject.tag == "Quest")
        {
            Debug.Log("반전");
            move.isQuest = true;
            other.gameObject.SetActive(false);
            
        }
    }
}