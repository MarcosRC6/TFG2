using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPC : MonoBehaviour
{

    private Animator animator;
    private bool morder = true;
    public float xInicial, yInicial;
    public GameObject personaje;
    public GameObject gameover;

    void Start()
    {
        xInicial = personaje.transform.position.x;
        yInicial = personaje.transform.position.y;
        animator.SetBool("morder", morder);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            ActivarDesactivar();
        }
    }

    public void ActivarDesactivar()
    {
        gameover.SetActive(true);
    }
}
