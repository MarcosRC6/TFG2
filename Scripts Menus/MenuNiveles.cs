using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuNiveles : MonoBehaviour
{

    public void Volver()
    {
        SceneManager.LoadScene("SelectorSlot");
    }

    public void N1()
    {
        SceneManager.LoadScene("Nivel_1");
    }
    public void N2()
    {
        SceneManager.LoadScene("Nivel_2");
    }
    public void N3()
    {
        SceneManager.LoadScene("Nivel_3");
    }
}
