using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject back;
    public void OnClickTtril()
    {
        back.SetActive(true);

    }
    public void OnClickClose()
    {
        back.SetActive(false);
    }
}
