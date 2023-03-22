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
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpeed == true)
        {
            curSpeed = speed * 1.5f;

            timer -= Time.deltaTime;



            if (timer <= 0)
            {
                isSpeed = false;
            }
        }
        else
        {
            curSpeed = speed;
        }

        transform.position -= curSpeed * Vector3.right * Time.deltaTime;
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Slow")
        {
            isSpeed = true;
            timer = time;
            other.gameObject.SetActive(false);
        }
    }

}
