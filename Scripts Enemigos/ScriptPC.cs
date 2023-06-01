using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPC : MonoBehaviour
{

    private Animator animator;
    private bool morder = true;
    [SerializeField] private GameObject efectoMuerte;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("morder", morder);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ataque")
        {
            Instantiate(efectoMuerte, transform.position, Quaternion.identity);
            DestroyObject(gameObject);
        }
        if (collision.gameObject.GetComponent<CambioPlayer>().tieneItemPM == false)
        {
            if (collision.gameObject.CompareTag("PlayerItem"))
            {
                collision.gameObject.GetComponent<CambioPlayer>().CambioNormal();
            }

            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<CambioPlayer>().morir();
            }
        }
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
