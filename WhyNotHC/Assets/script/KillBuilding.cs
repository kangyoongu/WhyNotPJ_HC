using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBuilding : MonoBehaviour
{
    private Transform player;
    void Start()
    {
        if (gameObject.name != "low" && gameObject.name != "map")
        {
            player = GameObject.Find("player").transform;
            StartCoroutine(Test());
        }
    }
    IEnumerator Test()
    {
        while (true)
        {
            if(transform.position.x + 120 < player.position.x)
            {
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
