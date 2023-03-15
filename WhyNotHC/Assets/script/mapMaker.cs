using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapMaker : MonoBehaviour
{
    public Transform player;
    public GameObject build;
    int z = -3;
    public Text sc;
    void Update()
    {
        if(player.position.z/25 > z)
        {
            z += 1;
            Instantiate(build, new Vector3(Random.Range(-10f, 10), -32.8622f, (z + 3) * 25), Quaternion.identity);
        }
        sc.text = (z-1).ToString("0");
    }
}
