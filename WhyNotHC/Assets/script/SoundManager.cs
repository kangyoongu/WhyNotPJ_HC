using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixer master; //public : ��𼭵� ���� �� �� ����
                              //private: Ŭ������������ ���� ����

    public Slider _bgmSlider;
    public Slider _sfxSlider;

    public void BGMChange()
    {
        master.SetFloat("BGM", _bgmSlider.value);
    }
    public void SFXChange()
    {
        master.SetFloat("SFX", _sfxSlider.value);
    }
}
