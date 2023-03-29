using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    
    [SerializeField] Transform item;
    [SerializeField] float curtime;
    [SerializeField] GameObject player;
    [SerializeField] float z;
    

    
    void Start()
    {
        
        
    }

    
    void Update()
    {
        
        curtime += Time.deltaTime;
        
        if(curtime > 10)
        {
            float itemX = Random.Range(-4.6f, 4.6f);
            z += Random.Range(50, 151);
            item = Instantiate(item, new Vector3(itemX, 0, z), Quaternion.identity);
            
            item.transform.position = new Vector3(itemX, 0, z);
            Debug.Log("Item");
            
            curtime = 0;
        }

    }

}
