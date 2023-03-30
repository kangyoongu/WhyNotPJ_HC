using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    

    Plane plane;

    private void Awake()
    {
        plane.SetNormalAndPosition(Camera.main.transform.forward * -1, Camera.main.transform.position + Camera.main.transform.forward * 3);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            plane.Raycast(ray, out float distance);

            Vector3 position = ray.GetPoint(distance);
            transform.position = new Vector3(-position.x + Camera.main.transform.position.x * 2, -position.y + Camera.main.transform.position.y * 2, position.z);
        }
    }
}