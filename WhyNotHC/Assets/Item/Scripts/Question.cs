using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{

    public Move1 move;
    [SerializeField] Timer timer;
    [SerializeField] float time = 5;
    bool isUpdate;
    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }
    private void Update()
    {
        if (move.isQuest == true)
        {
            if (isUpdate == true)
            {
                timer.Waitsecond(time, 5);
                isUpdate = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Quest")
        {
            isUpdate = true;
            move.isQuest = true;
            other.gameObject.SetActive(false);
        }
    }
}