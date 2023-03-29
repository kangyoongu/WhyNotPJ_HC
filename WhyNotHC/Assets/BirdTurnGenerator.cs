using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTurnGenerator : MonoBehaviour
{
    public GameObject birdPrefab;
    float delta = 0;
    float span = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;

        if (delta >= span)
        {
            delta = 0;
            GameObject Bird;
            Bird = Instantiate(birdPrefab);

            float x = 0;
            float y = 8;
            float z = Random.Range(0, 10);

            //Bird.transform.position = new(x, y, z);
        }
     }
}
