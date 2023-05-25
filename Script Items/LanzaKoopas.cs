using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzaKoopas : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float velocidad;
    [SerializeField] private float daño;
    private float direccion = 1f;

    private void Update()
    {

    }

    public void Inicializar(float direccionPersonaje)
    {
        direccion = direccionPersonaje;
    }

}
