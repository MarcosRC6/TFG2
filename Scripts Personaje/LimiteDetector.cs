using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LimiteDetector : MonoBehaviour
{
   
    public float limiteInferior = -925.9f; // Coordenada y del límite inferior
    public float xInicial, yInicial;
    private GameObject personaje; // Referencia al GameObject del personaje
    public GameObject gameover;

    void Start()
    {
        personaje = GameObject.FindWithTag("Player");
        xInicial = personaje.transform.position.x;
        yInicial = personaje.transform.position.y;
    }

    public void Update()
    {
        personaje = GameObject.FindWithTag("Player");

        if (personaje == null)
        {
            personaje = GameObject.FindWithTag("PlayerItem");
        }

        // Verificar la posición del personaje
        if (personaje.transform.position.y <= limiteInferior)
        {
            ActivarDesactivar();
        }
    }
    
    public void RecolocarPersonaje()
    {
        GameController.RestarVidas();
        BBDD.guaardarPartida(GameController.current.vidas, GameController.current.monedas);

        if (GameController.current.vidas > 0)
        {
            int escenaActual = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(escenaActual);
        }
        if (GameController.current.vidas == 0)
        {
            BBDD.borrarPartida();
            SceneManager.LoadScene("MenuInicio");
        }
    }

    public void ActivarDesactivar()
    {
        gameover.SetActive(true);
    }
}
