using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FastSpeed : MonoBehaviour
{
    public float time = 3.0f;
    public float Wtime = 10.0f;
    float timer = 3.0f;
    bool isSpeed;
    [SerializeField] float speed = 5f;
    [SerializeField] float curSpeed;
    public ParticleSystem par;
    public Move1 move;
    bool isEffect = false;
    
    
    void Update()
    {
        if (isSpeed == true)
        {
            curSpeed = speed * 1.5f;

            timer -= Time.deltaTime;
            move.moveSpeed = 700;
            
            if(isEffect == true)
            {
                par.Play();
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
        if(other.gameObject.tag == "Fast")
        {
            isSpeed = true;
            isEffect = true;
            timer = time;
            Destroy(other.gameObject);
        }
    }

}
