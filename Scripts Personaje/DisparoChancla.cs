using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoChancla : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;
    private bool puedeDisparar = true;


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    public void Disparar()
    {
        if (puedeDisparar)
        {
            GameObject balaObject = Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
            Bala balaScript = balaObject.GetComponent<Bala>();
            if (balaScript != null)
            {
                balaScript.Inicializar(controladorDisparo.parent.localScale.x);

            }
            
           

            puedeDisparar = false;
            Invoke("ResetearDisparo", 3f); // Invocar el m�todo para permitir el disparo despu�s de 5 segundos
        }
    }

    private void ResetearDisparo()
    {
        puedeDisparar = true;
    }


}
