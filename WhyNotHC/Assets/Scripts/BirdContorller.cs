using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdContorller : MonoBehaviour
{
    //private Transform _cube;
    public float time = 0.1f;
    public float deadtime = 0.1f;
    public float speed = 0.1f;
    public bool isDead = false;
    private Vector3 destination;
    private Rigidbody rb;
    public float push = 1.0f;
    public float calltime = 0.1f;

    void Start()
    {
        isDead = false;
        rb = GetComponent<Rigidbody>();
        //_cube = GameObject.Find("Cube").transform;
        //destination = _cube.position;

    }

    
    void Update()
    {
        if(isDead == false)
        {
            transform.Translate(-0.1f, 0, 0);
            
            //transform.position = Vector3.MoveTowards(transform.position, destination, speed);
            
        }
        if(transform.position.x<-8)
        {
            Destroy(gameObject);
        }
       
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        isDead = true;
        collision.transform.GetComponent<Rigidbody>().AddForce(transform.forward * push);
        StartCoroutine("Dead");
    }



    IEnumerator Dead()
    {
        rb.useGravity = true;
        yield return new WaitForSeconds(deadtime);
        Destroy(gameObject);
    }
}
