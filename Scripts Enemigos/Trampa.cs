using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    public float xInicial, yInicial;
    private GameObject personaje;
    public GameObject ControlSuperado;
    private GameObject TrampaAlta;
    void Start()
    {
        
        personaje = GameObject.FindWithTag("Player");

        if (personaje == null)
        {
            personaje = GameObject.FindWithTag("PlayerItem");
        }
        xInicial = ControlSuperado.transform.position.x;
        yInicial = ControlSuperado.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        TrampaAlta = GameObject.FindWithTag("TrampaAlta");
        personaje = GameObject.FindWithTag("Player");

        if (personaje == null)
        {
            personaje = GameObject.FindWithTag("PlayerItem");
        }

        xInicial = ControlSuperado.transform.position.x;
        yInicial = ControlSuperado.transform.position.y;

        Detector();
    }

    public void Detector()
    {
        if (personaje.transform.position.x >= xInicial && personaje.transform.position.y >= yInicial)
        {
            TrampaAlta.GetComponent<Collider2D>().isTrigger = true;
        }
    }
}

