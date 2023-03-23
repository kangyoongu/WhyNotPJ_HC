using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMaker : MonoBehaviour
{
    public Transform player;
    public GameObject build;
    public int z = -3;
    public int l = -75;
    public GameObject low;
    void Update()
    {
        if(player.position.z/25 > z)
        {
            z += 1;
            Instantiate(build, new Vector3(Random.Range(-8f, 8f), 0, (z + 3) * 25), Quaternion.identity);//앞으로 갈때마다 빌딩 생성
        }
        if (player.position.z/2 > l)
        {
            l += 1;
            Instantiate(low, new Vector3(Random.Range(-25f, 25), Random.Range(-3, 3), (l+37) * 2), Quaternion.identity);//작은 빌딩 생성
        }
    }
}
