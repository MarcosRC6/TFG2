using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaVolumen : MonoBehaviour
{

    public Slider slider;
    public float valorSlider;
    public Image mute;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("VolumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        Muteado();
    }

    public void CambioSlider(float valor)
    {
        valorSlider = valor;
        PlayerPrefs.SetFloat("VolumenAudio", valorSlider);
        AudioListener.volume = slider.value;
        Muteado();
    }

    public void Muteado()
    {
        if(valorSlider == 0)
        {
            mute.enabled = true;
        }else
        {
            mute.enabled = false;
        }
    }
}
