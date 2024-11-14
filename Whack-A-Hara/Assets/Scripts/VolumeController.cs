using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider musicSlider;
    public Slider effectSlider;

    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(MusicController);
        effectSlider.onValueChanged.AddListener(EffectController);
    }
    private void MusicController(float value)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }
    private void EffectController(float value)
    {
        mixer.SetFloat("EffectsVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("EffectsVolume", effectSlider.value);
    }
    public void Charge()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        effectSlider.value = PlayerPrefs.GetFloat("EffectsVolume", 0.75f);
        MusicController(musicSlider.value);
        EffectController(effectSlider.value);
    }
    void Start()
    {
        Charge();
    }

    void Update()
    {
        
    }
}
