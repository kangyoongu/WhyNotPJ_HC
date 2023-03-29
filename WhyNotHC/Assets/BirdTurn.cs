using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTurn : MonoBehaviour
{
    //private Transform _cube;
    public float deadtime = 0.1f;
    public bool isDead = false;
    private Rigidbody rb;
    public float push = 1.0f;

    float rightMax = 3.0f;  
    float leftMax = -3.0f;   
    float currentPosition;  
    float direction = 3.0f;  

    void Start()
    {
        isDead = false;
        rb = GetComponent<Rigidbody>();
        currentPosition = transform.position.x;
    }


    void Update()
    {
        if (isDead == false)
        {
            //currentPosition += Time.deltaTime * direction;
            if (currentPosition >= rightMax)
            {
                direction *= -1;
                currentPosition = rightMax;
            }
            else if (currentPosition <= leftMax)
            {
                direction *= -1;
                currentPosition = leftMax;
            }
            transform.position = new Vector3(currentPosition, 8, 5);
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
