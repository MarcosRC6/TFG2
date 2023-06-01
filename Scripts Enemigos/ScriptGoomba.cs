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
    private GameObject personaje;
    private CambioPlayer Personaje;
    private Rigidbody2D MyRB;
    [SerializeField] private GameObject efectoMuerte;

    void Start()
    {
        personaje = GameObject.FindWithTag("Player");
        if (personaje == null)
        {
            personaje = GameObject.FindWithTag("PlayerItem");
        }
        MyRB = GetComponent<Rigidbody2D>();
        MoveToA = true;
        animator = GetComponent<Animator>();
        Personaje = FindObjectOfType<CambioPlayer>();

    }

    void Update()
    {
        personaje = GameObject.FindWithTag("Player");
        Personaje = FindObjectOfType<CambioPlayer>();

        if (personaje == null)
        {
            personaje = GameObject.FindWithTag("PlayerItem");
            Personaje = FindObjectOfType<CambioPlayer>();
        }

        if (canMove)
        {
            mover();
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

            MyRB.transform.position = Vector2.MoveTowards(transform.position, new Vector2(PuntoB.position.x, transform.position.y), speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, PuntoB.position) < 0.1f)
            {
                MoveToA = true;
                MoveToB = false;
                
            }

            animator.SetBool("andar", andando);
        }

        if (MoveToA)
        {
            andando = true;

            MyRB.transform.position = Vector2.MoveTowards(transform.position, new Vector2(PuntoA.position.x, transform.position.y), speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, PuntoA.position) < 0.1f)
            {
                
                MoveToA = false;
                MoveToB = true;
                
            }

            animator.SetBool("andar", andando);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Punto"))
        {
            MoveToA = !MoveToA;
            MoveToB = !MoveToB;
            
        }

        if (collision.gameObject.GetComponent<CambioPlayer>().tieneItemPM == false)
        {
            if (collision.gameObject.tag == "Player" && Mathf.Abs(gameObject.transform.position.y - collision.gameObject.transform.position.y) < 2.5f)
            {
                if (Mathf.Abs(gameObject.transform.position.x - collision.gameObject.transform.position.x) < 1.3f)
                {


                    float alturaSalto = 0.2f;

                    Personaje.hit = true;
                    personaje.transform.Translate(Vector3.up * alturaSalto);
                    canMove = false;
                    morir = true;
                    animator.SetBool("morir", morir);
                    Invoke("DestroyObject", 0.25f);

                }
                else
                {
                    collision.gameObject.GetComponent<CambioPlayer>().morir();
                }
            }
        }

        if (collision.gameObject.GetComponent<CambioPlayer>().tieneItemPM == false)
        {
            if (collision.gameObject.tag == "PlayerItem" && Mathf.Abs(gameObject.transform.position.y - collision.gameObject.transform.position.y) < 2.5f)
            {
                if (Mathf.Abs(gameObject.transform.position.x - collision.gameObject.transform.position.x) < 1.3f)

                {
                    float alturaSalto = 0.2f;

                    Personaje.hit = true;
                    personaje.transform.Translate(Vector3.up * alturaSalto);
                    canMove = false;
                    morir = true;
                    animator.SetBool("morir", morir);
                    Invoke("DestroyObject", 0.25f);
                }
                else
                {
                    collision.gameObject.GetComponent<CambioPlayer>().CambioNormal();
                }
            }
        }

        if (collision.gameObject.tag == "Ataque")
        {
            Instantiate(efectoMuerte, transform.position, Quaternion.identity);
            DestroyObject(gameObject);
        }


    }

    private void Flip()
    {

        Vector2 ls = gameObject.transform.localScale;
        ls.x *= -1;
        transform.localScale = ls;
    }
}

