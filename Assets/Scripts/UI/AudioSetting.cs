using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup mixerGroup;
    [SerializeField] private float _sliderValue;

    private void Start()
    {
        _sliderValue = GetComponent<Slider>().value;
    }

    public void ChangeMasterValue()
    {
        GetSliderValue();
        mixerGroup.audioMixer.SetFloat("Master", _sliderValue);
    }

    public void ChangeEnviromentValue()
    {
        GetSliderValue();
        mixerGroup.audioMixer.SetFloat("Enviroments", _sliderValue);
    }
    public void ChangeMusicValue()
    {
        GetSliderValue();
        mixerGroup.audioMixer.SetFloat("Music", _sliderValue);
    }
    public void ChangeSystemValue()
    {
        GetSliderValue();
        mixerGroup.audioMixer.SetFloat("System", _sliderValue);
    }

    public void ChangePersonValue()
    {
        GetSliderValue();
        mixerGroup.audioMixer.SetFloat("Persons", _sliderValue);
    }
    private void GetSliderValue()
    {
        _sliderValue = GetComponentInParent<Slider>().value;
    }
}
