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
        float z = player.transform.position.z - 12;
        float y = player.transform.position.y + 10;
        transform.position = new Vector3(player.transform.position.x, y, z);
    }
}
