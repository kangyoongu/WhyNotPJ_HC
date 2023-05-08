using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{

    public Move1 move;
    [SerializeField] Timer timer;
    [SerializeField] float time;
    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }
    private void Update()
    {
        if(move.isQuest == true)
            timer.Waitsecond(time);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Quest")
        {
            
            move.isQuest = true;
            other.gameObject.SetActive(false);
        }
    }
}