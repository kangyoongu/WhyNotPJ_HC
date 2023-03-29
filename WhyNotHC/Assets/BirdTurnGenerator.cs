using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTurnGenerator : MonoBehaviour
{
    public GameObject birdPrefab;
    float delta = 0;
    float span = 0.0f;
    float boob = 0.0f;
    public bool isboom = true;
    void Start()
    {
        span = Random.Range(5, 15);
        delta += Time.deltaTime;

        if (delta >= span)
        {
            delta = 0;
            GameObject Bird;
            Bird = Instantiate(birdPrefab);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isboom == false)
        {
            span = Random.Range(5, 15);
            delta += Time.deltaTime;

            if (delta >= span)
            {
                delta = 0;
                GameObject Bird;
                Bird = Instantiate(birdPrefab);
                isboom = true;
            }
        }
     }
    public void Boom()
    {
        StartCoroutine(BoomTime());

    }

    IEnumerator BoomTime()
    {
        isboom = true;
        boob = Random.Range(5, 15);
        yield return new WaitForSeconds(boob);
        isboom = false;
    }
}
