using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController Instance;

    public void TimeSet(float time)
    {
        Time.timeScale = time;
    }
    

    private void Awake()
    {
        Instance = this;
    }
}
