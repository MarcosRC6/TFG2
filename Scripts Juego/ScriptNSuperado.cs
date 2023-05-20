using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptNSuperado : MonoBehaviour
{
    public GameObject ControlSuperado;
    public GameObject NivelSuperado;
    public GameObject PantallaSuperado;
    public GameObject personaje;
    public float xInicial, yInicial;
    // Start is called before the first frame update
    void Start()
    {

        xInicial = ControlSuperado.transform.position.x;
        yInicial = ControlSuperado.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        Superado();
        Invoke("PSuperado", 2f);
    }

    public void Superado()
    {
        if (personaje.transform.position.x >= xInicial && personaje.transform.position.y >= yInicial)
        {
            NivelSuperado.SetActive(true);
        }
    }

    public void PSuperado()
    {
        if (personaje.transform.position.x >= xInicial && personaje.transform.position.y >= yInicial)
        {
            PantallaSuperado.SetActive(true);
        }
    }
}
