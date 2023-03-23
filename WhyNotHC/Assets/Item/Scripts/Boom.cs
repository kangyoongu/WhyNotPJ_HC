using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Boom : MonoBehaviour
{
    
    
    //boom 태그에 닿으면 게임오버신 전환
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boom")
        {
            other.gameObject.SetActive(false);
            SceneChange();
        }

    }
    public void SceneChange()
    {
        SceneManager.LoadScene(1);
    }
}
