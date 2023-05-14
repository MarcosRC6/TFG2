using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicaCalidad : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int calidad;
    

    // Start is called before the first frame update
    void Start()
    {
        calidad = PlayerPrefs.GetInt("numeroCalidad", 3);
        dropdown.value = calidad;
        AjusteCalidad();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AjusteCalidad()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numeroCalidad", dropdown.value);
        calidad = dropdown.value;
    }
}
