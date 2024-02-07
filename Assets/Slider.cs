using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class Slider_display : MonoBehaviour
{
    public TMP_Text Slider_value;
    public Slider Sound_slider;
    public int min_value = 0;
    public int max_value = 100;

    
    // Start is called before the first frame update
    public void Start()
    {
        Sound_slider.minValue = min_value; 
        Sound_slider.maxValue = max_value;
        Slider_value.text = Sound_slider.value.ToString();
    }

    // Update is called once per frame
    public void Update()
    {
        Slider_value.text = Sound_slider.value.ToString();

    }
    // 슬라이더마다 
    public void MasterChanged()
    {
        SoundManager.Instance.SetMasterVolume(Sound_slider.value/100);
    }

    public void SfxChanged()
    {
        SoundManager.Instance.SetSFXVolume(Sound_slider.value/100);
    }

    public void BGMChanged()
    {
        SoundManager.Instance.SetBGMVolume(Sound_slider.value / 100);
    }






















}
