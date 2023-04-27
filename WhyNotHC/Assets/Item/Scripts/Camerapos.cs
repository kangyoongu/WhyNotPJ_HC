using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerapos : MonoBehaviour
{
    GameOver player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<GameOver>();
    }

    // Update is called once per frame
    void Update()
    {
        float z = player.transform.position.z - 15;
        float y = player.transform.position.y + 13;
        transform.position = new Vector3(player.transform.position.x, y, z);
    }
}
