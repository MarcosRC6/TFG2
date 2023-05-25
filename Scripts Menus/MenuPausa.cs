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

        string nombreEscenaActual = SceneManager.GetActiveScene().name;
        

        // Aqu� establece el nombre de la escena siguiente en funci�n del nombre de la escena actual
        if (nombreEscenaActual == "Nivel_1")
        {
            SceneManager.LoadScene("Nivel_2");
        }
        if (nombreEscenaActual == "Nivel_2")
        {
            SceneManager.LoadScene("Nivel_3");
        }
        else
        {
            Debug.LogWarning("No hay m�s niveles disponibles.");
        }
    }
}
