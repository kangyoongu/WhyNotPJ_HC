using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCallback : MonoBehaviour
{
    public GameObject back;
    private void OnParticleSystemStopped()
    {
        back.SetActive(true);
    }
}
