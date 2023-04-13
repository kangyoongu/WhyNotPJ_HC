using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGenerator : MonoBehaviour
{
    public GameObject birdPrefab;
    float delta = 0;
    public float span;
    public Transform _cube;
    public Vector3 curVector;
    int _randNum = 0;
    private OilManager oilManager;
    [SerializeField] GameObject player;
    private BirdContorller bird;
    float startTime;
    float playTime;


    private void Awake()
    {
        oilManager = player.transform.GetComponent<OilManager>();
        bird = birdPrefab.transform.GetComponent<BirdContorller>();
        
    }
    void Update()
    {
       ;

            delta += Time.deltaTime;
            if (delta >= span)
            {

                _randNum = Random.Range(0, 2);
                float x = _randNum == 0 ? 15 : -15;
                float y = Random.Range(_cube.position.y - 1, _cube.position.y + 2);
                float z = Random.Range(_cube.position.z + 8, _cube.position.z + 11);
                GameObject Bird = Instantiate(birdPrefab);
                Bird.transform.position = new(x, y, z);
                span = Random.Range(5, (400-oilManager.score)*0.1f < 10 ? 10 : (400 - oilManager.score) * 0.1f);
                delta = 0;

            
        }



        if (oilManager.bar.fillAmount <= 0f)
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
