using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] GameObject item;
    [SerializeField] float curtime;
    [SerializeField] GameObject player;
    
    [SerializeField] string tagName;
    private OilManager oilManager;
    private float lastZ;
    public bool isSpawn = true;

    private void Awake()
    {
        oilManager = player.transform.GetComponent<OilManager>();
    }


    void Update()
    {
        
        curtime += Time.deltaTime;
        
        if(curtime > 0.1)
        {
            
            if (isSpawn == true)
            {
                float itemX = Random.Range(-4.6f, 4.6f);
                lastZ = lastZ + Random.Range(10, 80);
                GameObject temp = Instantiate(item, new Vector3(itemX, 0, lastZ), Quaternion.identity);
                Debug.Log("Item");
            }
            
            
            curtime = 0;
        }

        if (oilManager.bar.fillAmount <= 0f)
        {
            isSpawn = false;

            GameObject[] delItems = GameObject.FindGameObjectsWithTag(tagName);
            
            foreach (var delItem in delItems)
            {
                Destroy(delItem);
            }
            gameObject.SetActive(false);
        }
    }
    public void itemRespawn()
    {
        gameObject.SetActive(true);
        isSpawn = true; 
    }

}
