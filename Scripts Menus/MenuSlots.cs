using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuSlots : MonoBehaviour
{

    public void Volver()
    {
        SceneManager.LoadScene("MenuInicio");
    }

    public void Temporal(int idPartida)
    {
        BBDD.seleccionarPartida(idPartida);
        if (!BBDD.Comprobarslot(idPartida))
            BBDD.nuevaPartida();

        SceneManager.LoadScene("Selector_lvl");
    }

    public void Borrar(int idPartida)
    {
        BBDD.seleccionarPartida(idPartida);
        BBDD.borrarPartida();
    }

}
