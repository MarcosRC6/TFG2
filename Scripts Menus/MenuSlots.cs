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

    public void Temporal()
    {
        SceneManager.LoadScene("Selector_lvl");
    }

}
