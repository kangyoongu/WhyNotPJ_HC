using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowSpeed : MonoBehaviour
{
    public float time = 3.0f;
    public float Wtime = 10.0f;
    float timer = 3.0f;
    bool isSpeed;
    [SerializeField] float speed = 5f;
    [SerializeField] float curSpeed;
    public ParticleSystem par;
    public move1 move;
    bool isEffect = false;
    


    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        var mainModule = par.main;
        if (isSpeed == true)
        {
            curSpeed = speed * 1.5f;

            timer -= Time.deltaTime;
            move.moveSpeed = 100;
            
            if (isEffect == true)
            {
                par.Play();
                mainModule.startSpeed = 50;
                isEffect = false;
                
            }



            if (timer <= 0)
            {
                isSpeed = false;
                move.moveSpeed = 300;
                par.Stop();
            }
        }
        else
        {
            curSpeed = speed;
        }

        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Slow")
        {
            isSpeed = true;
            timer = time;
            other.gameObject.SetActive(false);
            Debug.Log("slow");
        }
    }

}
