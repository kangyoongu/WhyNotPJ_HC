using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] GameObject item;
    [SerializeField] float curtime;
    [SerializeField] GameObject player;
    [SerializeField] float del = 0.5f;
    
    [SerializeField] string tagName;
    private OilManager oilManager;
    private float lastZ;
    public bool isSpawn = true;
    float itemX;


    private void Awake()
    {
        oilManager = player.transform.GetComponent<OilManager>();
    }
    void Update()
    {

        if (oilManager.bar.fillAmount <= 0f)
        {
            isSpawn = false;
            lastZ = 0;//�ʱ�ȭ
            itemX = 0;
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
    public IEnumerator itemSpawning()
    {
        if (isSpawn == true)
        {
            itemX = Random.Range(-5f, 5f);
            lastZ = lastZ + Random.Range(100, 500);//������ �Ÿ�
            GameObject temp = Instantiate(item);
            temp.transform.position = new Vector3(itemX, 0, lastZ);
            yield return new WaitForSeconds(0.1f);
        }
    }
    

}
