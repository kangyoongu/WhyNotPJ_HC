using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    
    [SerializeField] GameObject item;
    [SerializeField] float curtime;
    

    
    void Start()
    {
        
        
    }

    
    void Update()
    {
        
        curtime += Time.deltaTime;
        
        if(curtime > 10)
        {
            float itemX = Random.Range(-4.6f, 4.6f);
            float itemz = 20;
            
            item = Instantiate(item, new Vector3(itemX, -3, itemz), Quaternion.identity);
            itemz += 1;
            item.transform.position = new Vector3(itemX, -3, itemz);
            Debug.Log("Item");
            
            curtime = 0;
        }

    }

}
