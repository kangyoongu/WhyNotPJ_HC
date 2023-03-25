using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    //public bool isItemspawn;
    //int item;
    public GameObject item;
    public float curtime;
    

    
    void Start()
    {
        //isItemspawn = false;
        
    }

    
    void Update()
    {
        //for (int i = 0; i < 10; i++)
        //{
        //    item += 1;
        //    if (isItemspawn == true)
        //    {

        //        if(item == 10)
        //        {
        //            StartCoroutine(moveItem());
        //            item += 1;
        //        }

        //    }
        //    else
        //    {
        //        StartCoroutine(itemspawn());
        //    }
        //}
        curtime += Time.deltaTime;

        if(curtime > 3)
        {
            float newX = Random.Range(-4.6f, 4.6f);

            Instantiate(item, new Vector3(newX, -3, 14.4f), Quaternion.identity);

            item.transform.position = new Vector3(newX, -3, 14.4f);

            curtime = 0;
        }

    }
    
    //IEnumerator itemspawn()
    //{
    //    yield return new WaitForSeconds(1f);
    //    isItemspawn = true;
        
    //}
    //IEnumerator moveItem()
    //{
    //    yield return new WaitForSeconds(1f);
    //    transform.position = new Vector3(Random.Range(-4.6f, 4.6f), -3, 14.4f);
    //    item += 1; 
    //    isItemspawn = false;
    //}

}
