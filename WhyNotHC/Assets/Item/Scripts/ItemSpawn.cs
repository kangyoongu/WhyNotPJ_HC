using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    
    public GameObject item;
    public float curtime;
    

    
    void Start()
    {
        //isItemspawn = false;
        
    }

    
    void Update()
    {
        
        curtime += Time.deltaTime;

        if(curtime > 3)
        {
            float newX = Random.Range(-4.6f, 4.6f);
            float newz = 20;
            Instantiate(item, new Vector3(newX, -3, newz), Quaternion.identity);

            item.transform.position = new Vector3(newX, -3, newz);
            newz += 1;
            curtime = 0;
        }

    }
}
