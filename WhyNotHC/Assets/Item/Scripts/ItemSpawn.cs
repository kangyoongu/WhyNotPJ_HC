using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    
    [SerializeField] Transform item;
    [SerializeField] GameObject iTem;
    [SerializeField] float curtime;
    [SerializeField] GameObject player;
    [SerializeField] float z;
    [SerializeField] List<GameObject> itemSpawn = new List<GameObject>();
    bool isSpawn = true;
    
    

    
    void Start()
    {
        
        
    }

    
    void Update()
    {
        
        curtime += Time.deltaTime;
        
        if(curtime > 0.1)
        {
            
            if (isSpawn == true)
            {
                float itemX = Random.Range(-4.6f, 4.6f);
                z += Random.Range(50, 76);
                item = Instantiate(item, new Vector3(itemX, 0, z), Quaternion.identity);
                itemSpawn.Add(iTem);
                item.transform.position = new Vector3(itemX, 0, z);
                Debug.Log("Item");
            }
            
            
            curtime = 0;
        }
        

    }
    public void itemRespawn()
    {
        isSpawn = true;
        gameObject.SetActive(true);
        z = 0;
    }

}
