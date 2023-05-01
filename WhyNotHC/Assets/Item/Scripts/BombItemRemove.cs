using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItemRemove : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("maps"))
        {
            Destroy(gameObject);
        }
    }
}
