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
    GameObject b;
    public Transform gp;
    public GameObject gold;
    public OilManager oilManager;
    void Update()
    {
        if(player.position.z/25 > z)
        {
            z += 1;
            b = Instantiate(build, new Vector3(Random.Range(-8f, 8f), 0, (z + 3) * 25), Quaternion.identity);//앞으로 갈때마다 빌딩 생성
            float scale = (600 - oilManager.score) * 0.0016666f > 0.5f ? (600 - oilManager.score) * 0.0016666f : 0.5f;
            b.transform.root.transform.localScale = new Vector3(scale, 1, scale);
            b = b.transform.GetChild(0).GetChild(0).gameObject;
            Vector3 end = b.transform.position;
            Vector3 str = gp.position;
            Vector3 center = (str + end) * 0.5f;
            center.y -= 10;
            end = end - center;
            str = str - center;
            for(int i = 1; i < 5; i++)
            {
                gp.position = Vector3.Slerp(str, end, i/5f);
                gp.position += center;
                Instantiate(gold, gp.position, Quaternion.identity);
                gp.position -= center;

            }
            gp.position = b.transform.position;
        }
        if (player.position.z/2 > l)
        {
            l += 1;
            Instantiate(low, new Vector3(Random.Range(-25f, 25), Random.Range(-3, 3), (l+37) * 2), Quaternion.identity);//작은 빌딩 생성 
        }
    }
}
