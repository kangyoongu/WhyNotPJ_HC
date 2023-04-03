using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTurn : MonoBehaviour
{
    //private Transform _cube;
    public float deadtime = 0.1f;//Á×±â Àü ´ë±â½Ã°£
    public bool isDead = false;
    private Rigidbody _rb;
    public float push = 1.0f;//¹Ì´Â Èû
    private Transform Player;

    float rightMax = 3.0f;  
    float leftMax = -3.0f;   
    float currentPosition;  
    float direction = 3.0f;  

    void Start()
    {
        Player = GameObject.Find("Player").transform;
        StartCoroutine(_qwe());
    }


    void Update()
    {
        if (isDead == false)
        {
            
           
            currentPosition += Time.deltaTime * direction;
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
            transform.position = new Vector3(0 ,Player.position.y, Player.position.z+15);
        }
      

    }

    private void OnCollisionEnter(Collision collision)
    {
        isDead = true;
        //collision.transform.GetComponent<Rigidbody>().AddForce(transform.forward * push);
        StartCoroutine("Dead");

        BirdTurnGenerator birdGenerator = FindObjectOfType<BirdTurnGenerator>();
        birdGenerator.Boom();
    }

    IEnumerator Dead()
    {
        _rb.useGravity = true;
        yield return new WaitForSeconds(deadtime);
        Destroy(gameObject);
    }

    IEnumerator _qwe()
    {
        yield return new WaitForSeconds(5);
        isDead = false;
        _rb = GetComponent<Rigidbody>();
        currentPosition = transform.position.x;

    }
}
