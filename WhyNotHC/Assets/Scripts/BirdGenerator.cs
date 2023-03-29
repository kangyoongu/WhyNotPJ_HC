using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGenerator : MonoBehaviour
{
    public GameObject birdPrefab;
    float delta = 0;
    float span = 1.0f;
    public Transform _cube;

    private void Start()
    {
        
    }
    void Update()
    {
        _cube = GameObject.Find("Cube").transform;
        delta += Time.deltaTime;
        
        if (delta >= span)
        {
            delta = 0;
            GameObject Bird;
            Bird = Instantiate(birdPrefab);
            float x = 8;
            float y = _cube.position.y;
            float z = Random.Range(0, 25);

            Bird.transform.position = new(x, y, z);
        }
    }

    
}
