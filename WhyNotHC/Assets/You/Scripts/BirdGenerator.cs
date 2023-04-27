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

    float x;
    public float x1;
    public float x2;


    private void Awake()
    {
        oilManager = player.transform.GetComponent<OilManager>();
        bird = birdPrefab.transform.GetComponent<BirdContorller>();
        
    }
    private void Start()
    {
        StartCoroutine(FlyBird());
    }

    IEnumerator FlyBird()
    {
        while(true)
        {
            x1 = _cube.position.x + 10;
            x2 = _cube.position.x - 10;
            _randNum = Random.Range(0, 2);
            x = _randNum == 0 ? x1 : x2;
           
            float y = Random.Range(_cube.position.y - 1, _cube.position.y + 2);
            float z = Random.Range(_cube.position.z + 8, _cube.position.z + 11);
            GameObject Bird = Instantiate(birdPrefab);
            Bird.transform.position = new(x, y, z);
            span = Random.Range(5, (400 - oilManager.score) * 0.1f < 10 ? 10 : (400 - oilManager.score) * 0.1f);

            yield return new WaitForSeconds(span);

        }
    }


    void Update()
    {
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
