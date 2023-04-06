using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdContorller : MonoBehaviour
{

    //public float time = 0.1f;
    //private Vector3 destination;
    //public float calltime = 0.1f;

    public bool isDead = false;//³«ÇÏ
    public float deadtime = 0.1f;//Á×±â Àü½Ã°£
    public float push = 1.0f;//¹Ì´Â Èû
    private Rigidbody _rb;
    public bool direction = true;
    public float speed = 0.1f;


    private Vector3 _moveDir = new Vector3(0, 0, 1f);


    void Start()
    {

        isDead = false;
        _rb = GetComponent<Rigidbody>();
        if (transform.position.x <= -15)
        {
            direction = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
            transform.rotation = Quaternion.Euler(0, -90, 0);

    }


    void Update()
    {
        if (isDead == false)
        {
            if (direction == false)
            {
                transform.Translate(_moveDir * speed * Time.deltaTime);
                if (transform.position.x > 15)
                    Destroy(gameObject);
            }

            else
            {
                transform.Translate(_moveDir * speed * Time.deltaTime);
                if (transform.position.x < -15)
                    Destroy(gameObject);
            }

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        isDead = true;
        if (other.collider.CompareTag("Player"))
        {
            if (direction)
                other.transform.GetComponent<Rigidbody>().AddForce(transform.right * -push, ForceMode.Impulse);
            else
                other.transform.GetComponent<Rigidbody>().AddForce(transform.right * push, ForceMode.Impulse);
            StartCoroutine("Dead");
        }
        else
            StartCoroutine("Dead");
    }



    IEnumerator Dead()
    {
        _rb.useGravity = true;
        yield return new WaitForSeconds(deadtime);
        Destroy(gameObject);
    }
}