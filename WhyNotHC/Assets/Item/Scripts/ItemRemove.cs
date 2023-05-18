using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRemove : MonoBehaviour
{
    [SerializeField]float itemRemoveTime = 100;
    void Start()
    {
        StartCoroutine(Remove());
    }
    IEnumerator Remove()
    {
        yield return new WaitForSeconds(itemRemoveTime);
        Destroy(gameObject);
    }
}
