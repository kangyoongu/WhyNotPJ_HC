using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMap : MonoBehaviour
{
    Transform play;
    private void Start()
    {
        play = GameObject.Find("player").transform;
        if(gameObject.name != "map" && gameObject.name != "low")
        {
            StartCoroutine(kill());
        }
    }
    IEnumerator kill()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if(play.position.z - transform.position.z >= 150)
            {
                Destroy(gameObject);
            }
        }
    }
}
