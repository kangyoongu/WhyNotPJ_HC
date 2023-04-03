using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTurnGenerator : MonoBehaviour
{
    public GameObject birdPrefab;
    float delta = 0;
    float span = 0.0f;//�����ð�
    float boob = 0.0f;//��ٸ��� �ð�
    public bool isboom = true;
    void Start()
    {
        span = Random.Range(5, 10);
        delta += Time.deltaTime;

        if (delta >= span)
        {
            delta = 0;
            GameObject Bird = Instantiate(birdPrefab);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isboom == false)
        {

                delta = 0;
                GameObject Bird = Instantiate(birdPrefab);
                isboom = true;
            
        }
    }
    public void Boom()
    {
        StartCoroutine(BoomTime());
    }

    IEnumerator BoomTime()
    {
        boob = Random.Range(5, 10);
        yield return new WaitForSeconds(boob);
        isboom = false;
    }
}
