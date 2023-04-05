using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTurn1 : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.forward * 170 * Time.deltaTime);
    }
}
