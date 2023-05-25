using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoCañon : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;
    private bool puedeDisparar = true;
    private Animator animator;
    private float duracionAnimacion = 2.5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(DispararCoroutine());
    }

    private void Update()
    {
        
        

    }

    /*public void Disparar()
    {
        if (puedeDisparar)
        {
            animator.SetBool("Disparo", true);
            GameObject balaObject = Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
            
        }
    }*/

    private IEnumerator DispararCoroutine()
    {
        while (true)
        {
            if (puedeDisparar)
            {
                animator.SetBool("Disparo", true);
                yield return new WaitForSeconds(1.25f); // Espera 1.25 segundos para sincronizar con la mitad de la animación
                GameObject balaObject = Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
                yield return new WaitForSeconds(duracionAnimacion - 1.25f); // Espera el tiempo restante de la animación
                animator.SetBool("Disparo", false); // Restablece el parámetro de animación a falso
            }

            yield return new WaitForSeconds(6f); // Espera 6 segundos antes del próximo disparo
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerItem")
        {
            puedeDisparar = false;
           
        }

    }
}
