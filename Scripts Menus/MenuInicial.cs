using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuInicial : MonoBehaviour
{
    private void Awake()
    {
        BBDD.Connect();
        BBDD.Create();
    }

    public void Jugar()
    {
        SceneManager.LoadScene("SelectorSlot");
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}

