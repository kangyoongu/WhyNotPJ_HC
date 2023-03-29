using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTurn : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up * 170 * Time.deltaTime);
    }
}
