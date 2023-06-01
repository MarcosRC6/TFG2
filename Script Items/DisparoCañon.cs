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
    public AudioSource audioCañon;

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
                yield return new WaitForSeconds(1.25f); 
                GameObject balaObject = Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
                audioCañon.Play();
                yield return new WaitForSeconds(duracionAnimacion - 1.25f);
                animator.SetBool("Disparo", false); 
            }

            yield return new WaitForSeconds(4f); 
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
