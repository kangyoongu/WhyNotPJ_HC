using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI tts;
    float t = 0;
    void Update()
    {
        t += Time.deltaTime*3;

        tts.color = new Color(1, 1, 1, Mathf.Sin(t) * 0.5f + 0.5f);
    }
}
