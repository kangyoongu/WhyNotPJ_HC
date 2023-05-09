using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum birdType { Straight, Chase,MAX}
public class BirdContorller : MonoBehaviour
{

    birdType bird;

    public bool isDead = false;//³«ÇÏ
    public float deadtime = 0.1f;//Á×±â Àü½Ã°£
    public float push = 1.0f;//¹Ì´Â Èû
    private Rigidbody _rb;
    public float speed = 0.1f;
    [SerializeField]AudioSource audioSource;
    BirdGenerator birdGener;
    private Vector3 pushDir;
    Transform Player;
    Vector3 Chase;

    void Start()
    {
        bird = (birdType)Random.Range(0, (int)birdType.MAX);
        birdGener = FindObjectOfType<BirdGenerator>();
        _rb = GetComponent<Rigidbody>();
        
        audioSource = GetComponent<AudioSource>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        switch (bird)
        {
            case birdType.Chase:
              transform.position = new(Player.position.x+Random.Range(-8,8), Player.position.y + Random.Range(-8, 8), Player.position.z + 30);
                pushDir = (Player.position - transform.position).normalized;
                transform.rotation = Quaternion.LookRotation(Player.position - transform.position, Vector3.up);
                break;
            case birdType.Straight:
                transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
        }
        Chase = (Player.position - transform.position).normalized;
    }


    void Update()
    {
       switch(bird)
        {
            case birdType.Chase:
                transform.position += Time.deltaTime * Chase * speed;
                break;
            case birdType.Straight:
                transform.position += Time.deltaTime *transform.forward   * speed;
                break;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        isDead = true;
        if (other.collider.CompareTag("Player"))
        {
            audioSource.Play();
                other.transform.root.GetComponent<Rigidbody>().AddForce(pushDir * push, ForceMode.Impulse);
      
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