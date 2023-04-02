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
        
        if(curtime > 0.5)
        {
            
            if (isSpawn == true)
            {
                float itemX = Random.Range(-4.6f, 4.6f);
                lastZ = lastZ + Random.Range(100, 500);//������ �Ÿ�
                GameObject temp = Instantiate(item);
                temp.transform.position = new Vector3(itemX, 0, lastZ);
                Debug.Log("Item");
            }

            curtime = 0;
            
        }

        if (oilManager.bar.fillAmount <= 0f)
        {
            isSpawn = false;
            lastZ = 0;//�ʱ�ȭ
            GameObject[] delItems = GameObject.FindGameObjectsWithTag(tagName);
            
            foreach (var delItem in delItems)
            {
                Destroy(delItem);//������ ���� ����
            }
            gameObject.SetActive(false);
        }
    }
    public void itemRespawn()//��ư �Լ�
    {
        gameObject.SetActive(true);
        isSpawn = true; 
    }

}
