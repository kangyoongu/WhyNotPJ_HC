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
            lastZ = 0;//초기화
            itemX = 0;
            GameObject[] delItems = GameObject.FindGameObjectsWithTag(tagName);

            foreach (var delItem in delItems)
            {
                Destroy(delItem);//아이템 전부 삭제
            }
            gameObject.SetActive(false);
        }
    }
    public void itemRespawn()//버튼 함수
    {
        gameObject.SetActive(true);
        isSpawn = true; 
    }
    public IEnumerator itemSpawning()
    {
        if (isSpawn == true)
        {
            itemX = Random.Range(-10f, 10f);
            lastZ = lastZ + Random.Range(100, 500);//아이템 거리
            GameObject temp = Instantiate(item);
            temp.transform.position = new Vector3(itemX, Random.Range(5, 10), lastZ);
            yield return new WaitForSeconds(0.1f);
        }
    }
    

}
