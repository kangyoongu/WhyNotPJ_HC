using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum birdType { Straight, Chase, MAX }
public class BirdContorller : MonoBehaviour
{

    birdType bird;

    public bool isDead = false;//����
    public float deadtime = 0.1f;//�ױ� ���ð�
    public float push = 1.0f;//�̴� ��
    private Rigidbody _rb;
    public float speed = 0.1f;
    [SerializeField] AudioSource audioSource;
    BirdGenerator birdGener;
    Transform Player;
    Vector3 Chase;
    Rigidbody player;
    private Vector3 _moveDir = new Vector3(0, 0, 1f);

    void Start()
    {
        bird = (birdType)Random.Range(0, (int)birdType.MAX);
        birdGener = FindObjectOfType<BirdGenerator>();

        isDead = false;
        player = GameObject.Find("player").GetComponent<Rigidbody>();

        _rb = GetComponent<Rigidbody>();

        audioSource = GetComponent<AudioSource>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        switch (bird)
        {
            case birdType.Chase:
                transform.position = new(Player.position.x /*+ Random.Range(-4, 4)*/, Player.position.y + Random.Range(-4, 4), Player.position.z + 50);
                transform.rotation = Quaternion.LookRotation(Player.position - transform.position, Vector3.up);
                break;
            case birdType.Straight:
                transform.position = new(Player.position.x /*+ Random.Range(-4, 4)*/, Player.position.y + Random.Range(-4, 4), Player.position.z + 50);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
        }
        Chase = (Player.position - transform.position).normalized;
    }


    void Update()
    {
        switch (bird)
        {
            case birdType.Chase:
                transform.position += Time.deltaTime * Chase * speed;
                break;
            case birdType.Straight:
                transform.position += Time.deltaTime * transform.forward * speed;
                break;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        isDead = true;
        if (other.collider.CompareTag("Player"))
        {
            audioSource.Play();
            player.velocity = Vector3.zero;
            //other.transform.root.GetComponent<Rigidbody>().AddForce(pushDir * push, ForceMode.Impulse);
           // player.AddExplosionForce(600f, transform.position, 100f, 0);
            Vector3 dir = player.transform.position - transform.position;
            dir = dir.normalized;
            player.velocity = new Vector3(dir.x * 15, 7, dir.z * 15);
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