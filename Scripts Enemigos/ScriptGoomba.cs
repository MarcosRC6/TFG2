using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGoomba : MonoBehaviour
{
    public Transform PuntoA;
    public Transform PuntoB;
    [Header("Animacion")]
    public bool MoveToA = false;
    public bool MoveToB = false;
    public float speed;
    public bool andando = false;
    public bool morir = false;
    public bool canMove = true;
    private Animator animator;
    private MovimientoJugador Personaje; 

    private Rigidbody2D MyRB;

    void Start()
    {
        
        MyRB = GetComponent<Rigidbody2D>();
        MoveToB = true;
        animator = GetComponent<Animator>();
        Personaje = FindObjectOfType<MovimientoJugador>();

    }

    void Update()
    {
        if (canMove)
        {
            mover();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Personaje.hit = true;
            canMove = false;
            morir = true;
            animator.SetBool("morir", morir);
            Invoke("DestroyObject", 0.5f);
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void mover()
    {
        if (MoveToB)
        {
            andando = true;

            MyRB.transform.position = Vector2.MoveTowards(transform.position, PuntoB.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, PuntoB.position) < 0.01f)
            {

                MoveToA = true;
                MoveToB = false;

            }
            animator.SetBool("andar", andando);

        }

        if (MoveToA)
        {
            andando = true;

            MyRB.transform.position = Vector2.MoveTowards(transform.position, PuntoA.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, PuntoA.position) < 0.01f)
            {
                MoveToA = false;
                MoveToB = true;

            }

            animator.SetBool("andar", andando);
        }
    }
}

