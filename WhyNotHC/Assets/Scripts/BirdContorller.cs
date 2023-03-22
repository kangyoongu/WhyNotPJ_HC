using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdContorller : MonoBehaviour
{
    public Transform _cube;
    public float time = 0.1f;
    public float speed = 0.1f;
    public bool isDead = false;
    Vector3 destination;
    public Rigidbody rb;

    void Start()
    {
        isDead = false;
        rb = GetComponent<Rigidbody>();
        _cube = GameObject.Find("Cube").transform;
        destination = _cube.position;

    }

    
    void Update()
    {
        if(isDead == false)
        {
            transform.LookAt(_cube);
            transform.position = Vector3.MoveTowards(transform.position, destination, speed);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        isDead = true;
        StartCoroutine("Dead");
    }

    IEnumerator Dead()
    {
        rb.useGravity = true;
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
