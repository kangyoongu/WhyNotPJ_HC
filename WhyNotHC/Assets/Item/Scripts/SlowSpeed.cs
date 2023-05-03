using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SlowSpeed : MonoBehaviour
{
    public float time = 3.0f;
    public float Wtime = 10.0f;
    float timer = 3.0f;
    bool isSpeed = false;
    [SerializeField] float speed = 5f;
    [SerializeField] float curSpeed;
    public ParticleSystem par;
    public Move1 move;
    bool isEffect = false;
    [SerializeField] Timer timerImage;

    bool isUpdate;
    private void Start()
    {
        timerImage = FindObjectOfType<Timer>();
    }
    void Update()
    {
        if (isSpeed == true)
        {
            
                curSpeed = speed * 1.5f;
            if (isUpdate == true)
            {
                timerImage.Waitsecond(time);
                isUpdate = false;
            }
                timer -= Time.deltaTime;

                move.moveSpeed = 100;

                if (isEffect == true)
                {
                    par.Play();
                    isEffect = false;
                }


                if (timer <= 0)
                {
                    isSpeed = false;

                    isUpdate = false;

                    move.moveSpeed = 300;
                    par.Clear();
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
            isEffect = true;

            isUpdate = true;

            timer = time;
            Destroy(other.gameObject);
        }
    }

}
