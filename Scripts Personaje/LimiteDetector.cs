using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteDetector : MonoBehaviour
{
   
    public float limiteInferior = -925.9f; // Coordenada y del límite inferior
    public float xInicial, yInicial;
    public GameObject personaje; // Referencia al GameObject del personaje
    public GameObject gameover;

    void Start()
    {
        xInicial = transform.position.x;
        yInicial = transform.position.y;
    }

    public void Update()
    {
        // Verificar la posición del personaje
        if (personaje.transform.position.y <= limiteInferior)
        {
            ActivarDesactivar();
        }
    }
    
    public void RecolocarPersonaje()
    {
        GameController.RestarVidas();
        Vector3 nuevaPosicion = new Vector3(xInicial, yInicial, 0f); // Coordenadas de ejemplo
        personaje.transform.position = nuevaPosicion;
    }

    public void ActivarDesactivar()
    {
        gameover.SetActive(true);
    }
}
