using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGenerator : MonoBehaviour
{
    public GameObject birdPrefab;
    float delta = 0;
    [SerializeField] float span = 5;
    public Transform _cube;
    public Vector3 curVector;
    int _randNum = 0;
    private OilManager oilManager;
    [SerializeField] GameObject player;
    private BirdContorller bird;


    private void Awake()
    {
        oilManager = player.transform.GetComponent<OilManager>();
        bird = birdPrefab.transform.GetComponent<BirdContorller>();
    }
    void Update()
    {
        
        delta += Time.deltaTime;
        if (delta >= span)
        {
 
            _randNum = Random.Range(0, 2);
            float x = _randNum == 0 ? 10 : -10;
            float y = Random.Range(_cube.position.y-1, _cube.position.y + 2); 
            float z = Random.Range(_cube.position.z + 8, _cube.position.z+11);
            GameObject Bird = Instantiate(birdPrefab);
            //curVector = new(x, y, z);
            Bird.transform.position = new(x, y, z);
            span = Random.Range(2, 8);
            delta = 0;

        }
        if(oilManager.bar.fillAmount <= 0f)
        {
            gameObject.SetActive(false);
        }

    }   
    public void birdsSpawn()
    {
        gameObject.SetActive(true);
    }
    public void startspawn()
    {
        gameObject.SetActive(true);
    }
}
