using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private float _sliderValue;

    private void Start()
    {
        _sliderValue = GetComponent<Slider>().value;
    }

    public void ChangeMasterValue()
    {
        GetSliderValue();
        _mixerGroup.audioMixer.SetFloat("Master", _sliderValue);
    }

    public void ChangeEnviromentValue()
    {
        GetSliderValue();
        _mixerGroup.audioMixer.SetFloat("Enviroments", _sliderValue);
    }
    public void ChangeMusicValue()
    {
        GetSliderValue();
        _mixerGroup.audioMixer.SetFloat("Music", _sliderValue);
    }
    public void ChangeSystemValue()
    {
        GetSliderValue();
        _mixerGroup.audioMixer.SetFloat("System", _sliderValue);
    }

    public void ChangePersonValue()
    {
        GetSliderValue();
        _mixerGroup.audioMixer.SetFloat("Persons", _sliderValue);
    }
    private void GetSliderValue()
    {
        _sliderValue = GetComponentInParent<Slider>().value;
    }

    public void TurnOffMixer() 
    {
        _mixerGroup.audioMixer.SetFloat("OffIfDie", -80);
    }
}
