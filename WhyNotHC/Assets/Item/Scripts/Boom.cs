using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Boom : MonoBehaviour
{
    
    
    //boom �±׿� ������ ���ӿ����� ��ȯ
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
