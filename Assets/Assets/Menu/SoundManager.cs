using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public Slider slider;
    public float sliderValue;
    public Image imgMute, imgLowSound, imgMidSound, imgHighSound;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        CheckMute();
    }

    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        CheckMute();
    }

    public void CheckMute()
    {
        if(sliderValue == 0)
        {
            imgMute.enabled = true;
            imgLowSound.enabled = false;
            imgMidSound.enabled = false;
            imgHighSound.enabled = false;
        }
        else if(sliderValue > 0 && sliderValue <= 0.33)
        {
            imgMute.enabled = false;
            imgLowSound.enabled = true;
            imgMidSound.enabled = false;
            imgHighSound.enabled = false;
        }
        else if (sliderValue >= 0.34 && sliderValue <= 0.66)
        {
            imgMute.enabled = false;
            imgLowSound.enabled = false;
            imgMidSound.enabled = true;
            imgHighSound.enabled = false;
        }
        else if (sliderValue >= 0.67 && sliderValue <= 1)
        {
            imgMute.enabled = false;
            imgLowSound.enabled = false;
            imgMidSound.enabled = false;
            imgHighSound.enabled = true;
        }
    }
}
