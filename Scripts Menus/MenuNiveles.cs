using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuNiveles : MonoBehaviour
{
    private int[] niveles;

    public void Awake()
    {
        niveles = BBDD.ComprobarNivels();
    }

    public void Volver()
    {
        SceneManager.LoadScene("SelectorSlot");
    }

    public void N1()
    {
        
            SceneManager.LoadScene("Nivel_1");
    }
    public void N2()
    {
        if (niveles[0] == 1)
            SceneManager.LoadScene("Nivel_2");
    }
    public void N3()
    {
        if (niveles[1] == 1)
            SceneManager.LoadScene("Nivel_3");
    }
}
