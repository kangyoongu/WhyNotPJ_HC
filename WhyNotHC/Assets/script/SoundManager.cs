using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixer master; //public : 어디서든 갖다 쓸 수 있음
                              //private: 클래스내에서만 접근 가능

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
