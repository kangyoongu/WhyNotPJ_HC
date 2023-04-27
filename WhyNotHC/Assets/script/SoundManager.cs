
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixer master;

    public Slider _bgmSlider;
    public Slider _sfxSlider;

    [SerializeField]
    Image _soundIcon;
    [SerializeField]
    Sprite _soundStopSprite;
    [SerializeField]
    Sprite _SoundOnSprite;

    [SerializeField]
    Image _bgmIcon;
    [SerializeField]
    Sprite _bgmStopSprite;
    [SerializeField]
    Sprite _bgmOnSprite;

    bool bgmOff = true;
    bool soundOff = true;

    public void BGMChange()
    {

        if (bgmOff == true)
        {
            
            master.SetFloat("BGM", -80);
            bgmOff = false;
            _bgmIcon.sprite = _bgmStopSprite;
        }
        else
        {
            master.SetFloat("BGM", 0);
            bgmOff = true;
            _bgmIcon.sprite = _bgmOnSprite;
        }
    }
    public void SFXChange()
    {
        if (soundOff == true)
        {
            master.SetFloat("SFX", -80);
            soundOff = false;
            _soundIcon.sprite = _soundStopSprite;
        }
        else
        {
            master.SetFloat("SFX", 0);
            soundOff = true;
            _soundIcon.sprite = _SoundOnSprite;
        }
    }
}

