using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemMaker : MonoBehaviour
{
    public Transform player;
    public GameObject build;
    public int z = -3;
    public int l = -75;
    public GameObject low;
    
    void Update()
    {
       
            if (player.position.z / 25 > z)
            {
                z += 1;
                Instantiate(build, new Vector3(Random.Range(-10f, 10), 0, (z + 3) * 25), Quaternion.identity);
            }
            if (player.position.z / 2 > l)
            {
                l += 1;
                Instantiate(low, new Vector3(Random.Range(-15f, 15), Random.Range(-3, 3), (l + 37) * 2), Quaternion.identity);
            }
        
        
    }
}
