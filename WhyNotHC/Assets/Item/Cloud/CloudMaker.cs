using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMaker : MonoBehaviour
{
    [SerializeField] GameObject cloud;
    Transform player;
    float delTime = 10;
    bool isSpawnCloud = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawnCloud == true)
        {
            GameObject cloudmove = Instantiate(cloud);
            float cloudpos = player.transform.position.z + 10;
            cloud.transform.position = new Vector3(0, 0, cloudpos);
            isSpawnCloud = false;
        }
        Invoke("WaitTime", delTime);
    }
    void WaitTime()
    {
        isSpawnCloud = true;
    }
}
