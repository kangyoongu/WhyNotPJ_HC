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
    Rigidbody rigid;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpeed == true)
        {
            curSpeed = speed * 1.5f;

            timer -= Time.deltaTime;
            transform.position += curSpeed * Vector3.forward * Time.deltaTime;
            rigid.useGravity = false;


            if (timer <= 0)
            {
                isSpeed = false;
                rigid.useGravity = true;
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
            timer = time;
            Destroy(other.gameObject);
        }
    }

}
