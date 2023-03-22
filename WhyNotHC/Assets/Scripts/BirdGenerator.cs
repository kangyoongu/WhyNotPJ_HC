using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGenerator : MonoBehaviour
{
    public GameObject birdPrefab;
    float delta = 0;
    float span = 1.0f;
    void Start()
    {
        
    }

    
    void Update()
    {
        delta += Time.deltaTime;
        
        if (delta >= span)
        {
            delta = 0;
            GameObject Bird;
            Bird = Instantiate(birdPrefab);
            float x = Random.Range(1,10);
            float y = Random.Range(1,10);
            float z = Random.Range(1, 10);
            Bird.transform.position = new Vector3(x,y,z);
        }
    }

    
}
