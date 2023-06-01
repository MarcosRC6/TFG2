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
        
        GameController.RestarVidas();
        BBDD.guaardarPartida(GameController.current.vidas, GameController.current.monedas);
        if (GameController.current.vidas > 0)
        {
            SceneManager.LoadScene("MenuInicio");
        }
        if (GameController.current.vidas == 0)
        {
            BBDD.borrarPartida();
            SceneManager.LoadScene("MenuInicio");
        }
    }

    public void SiguienteNivel()
    {
        int escenaActualIndex = SceneManager.GetActiveScene().buildIndex;
        int siguienteEscenaIndex = escenaActualIndex + 1;

        if (siguienteEscenaIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(siguienteEscenaIndex);
        }
        else
        {
            Debug.LogWarning("No hay más niveles disponibles.");
        }
    }
}
