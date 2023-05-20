using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] public GameObject botonPausa;
    [SerializeField] public GameObject menuPausa;
    public void Pausa()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void salir()
    {
        SceneManager.LoadScene("MenuInicio");
    }

    public void SiguienteNivel()
    {
        int indiceEscenas = SceneManager.GetActiveScene().buildIndex;
        int siguienteEscena = indiceEscenas + 1;

        if (siguienteEscena < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(siguienteEscena);
        }
        else
        {
            Debug.LogWarning("No hay más niveles disponibles.");
        }
    }
}
