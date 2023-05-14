using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LogicaResolucion : MonoBehaviour
{
    public Toggle toggle;
    public TMP_Dropdown resolucionDropDown;
    Resolution[] resoluciones;

    // Start is called before the first frame update
    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

        RevisarResolucion();
    }

    public void RevisarResolucion()
    {
        resoluciones = Screen.resolutions;
        resolucionDropDown.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;
        
        for (int i = 0; i<resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);

            if(Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width &&
                resoluciones[i].height == Screen.currentResolution.height)
            {
                resolucionActual = i;
            }

        }

        resolucionDropDown.AddOptions(opciones);
        resolucionDropDown.value = resolucionActual;
        resolucionDropDown.RefreshShownValue();

        resolucionDropDown.value = PlayerPrefs.GetInt("numeroResolucion", 0);
    }

    public void CambiarResolucion(int indiceResolucion)
    {
        resolucionDropDown.value = PlayerPrefs.GetInt("numeroResolucion", resolucionDropDown.value);
        Resolution resolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }



    // Update is called once per frame
    void Update()
    {

    }

    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }
}
