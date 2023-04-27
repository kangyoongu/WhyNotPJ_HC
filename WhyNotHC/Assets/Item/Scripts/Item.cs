using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Transform player;
    [SerializeField] float removeItem = 1;
    private void Awake()
    {
        player = GameObject.Find("player").transform;
    }
    private void Update()
    {
        if(player.position.z - transform.position.z >= removeItem)
        {
            Destroy(gameObject);
        }
    }
}
