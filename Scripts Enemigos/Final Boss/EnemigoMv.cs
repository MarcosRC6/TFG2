using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemigoMv : MonoBehaviour
{
    private Animator animator;
    public float speed;
    private GameObject objetivo;
    private CambioPlayer Personaje;

    public Transform PuntoA;
    public Transform PuntoB;
    public bool MoveToA = false;
    public bool MoveToB = false;
    private Rigidbody2D MyRB;

    public bool andar;
    public bool atacar;
    private float distanciaX;
    private bool coroutineStarted = false;

    [SerializeField] private Transform controladorDisparo1;
    [SerializeField] private Transform controladorDisparo2;
    [SerializeField] private Transform controladorDisparo3;
    [SerializeField] private GameObject bala;
    private bool puedeDisparar = true;

   
    private float duracionAnimacion = 1.5f;



    // Start is called before the first frame update
    void Start()
    {
       
        andar = true;
        MoveToA = true;
        MyRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        objetivo = GameObject.FindWithTag("Player");


        if (objetivo == null)
        {
            objetivo = GameObject.FindWithTag("PlayerItem");
        }


    }

    // Update is called once per frame
    void Update()
    {
        

        objetivo = GameObject.FindWithTag("Player");

        if (objetivo == null)
        {
            objetivo = GameObject.FindWithTag("PlayerItem");
        }
        Personaje = FindObjectOfType<CambioPlayer>();
        distanciaX = Mathf.Abs(objetivo.transform.position.x - transform.position.x);
        Giro();
        if (andar)
        {
            mover();
        }
        if (!andar)
        {
            Atacar();
           
        }


    }

    private int RandomN()
    {
        int randomNumber = Random.Range(1, 3);
        return randomNumber;
    }

    private Transform GetControladorDisparo(int numeroCD)
    {
        Transform controlador = null;

        switch (numeroCD)
        {
            case 1:
                controlador = controladorDisparo1;
                break;
            case 2:
                controlador = controladorDisparo2;
                break;
            case 3:
                controlador = controladorDisparo3;
                break;
            default:
                controlador = controladorDisparo3;
                break;
        }

        return controlador;
    }

    private IEnumerator DispararCoroutine()
    {
        while (true)
        {
            if (puedeDisparar)
            {
                if (andar)
                {
                    int numeroCD = RandomN();
                    Transform controlador = GetControladorDisparo(numeroCD);
                    animator.SetBool("DA", true);
                    GameObject balaObject = Instantiate(bala, controlador.position, controlador.rotation);
                }
                else
                {
                    int numeroCD = RandomN();
                    Transform controlador = GetControladorDisparo(numeroCD);
                    animator.SetBool("DA", true);
                    GameObject balaObject = Instantiate(bala, controlador.position, controlador.rotation);
                    animator.SetBool("DA", true);
                }
            }

            yield return new WaitForSeconds(4f);
        }
    }

   /* private IEnumerator DispararCoroutine()
    {
        while (true)
        {
            if (puedeDisparar)
            {
                if (andar)
                {
                    animator.SetBool("DA", true);
                    GameObject balaObject = Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
                }
                else
                {
                    animator.SetBool("disparar", true);
                    GameObject balaObject = Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
                    animator.SetBool("disparar", false);
                }
            }

            yield return new WaitForSeconds(6f);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Punto"))
        {
            if (!atacar)
            {
                MoveToA = !MoveToA;
                MoveToB = !MoveToB;
                Flip();
            }
            if (atacar)
            {
                MoveToA = !MoveToA;
                MoveToB = !MoveToB;
            }

        }
    }

    public void mover()
    {

        if (!atacar && andar)
        {
            if (MoveToB)
            {
                animator.SetBool("andar", true);
                MyRB.transform.position = Vector2.MoveTowards(transform.position, new Vector2(PuntoB.position.x, transform.position.y), speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, PuntoB.position) < 0.1f)
                {
                    MoveToA = true;
                    MoveToB = false;


                }
            }
            else if (MoveToA)
            {
                animator.SetBool("andar", true);
                MyRB.transform.position = Vector2.MoveTowards(transform.position, new Vector2(PuntoA.position.x, transform.position.y), speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, PuntoA.position) < 0.1f)
                {
                    MoveToA = false;
                    MoveToB = true;


                }
            }
        }
        if (atacar)
        {
            if (MoveToB)
            {
                animator.SetBool("DA", true);
                MyRB.transform.position = Vector2.MoveTowards(transform.position, new Vector2(PuntoB.position.x, transform.position.y), speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, PuntoB.position) < 0.1f)
                {
                    MoveToA = true;
                    MoveToB = false;


                }
            }
            else if (MoveToA)
            {
                animator.SetBool("DA", true);
                MyRB.transform.position = Vector2.MoveTowards(transform.position, new Vector2(PuntoA.position.x, transform.position.y), speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, PuntoA.position) < 0.1f)
                {
                    MoveToA = false;
                    MoveToB = true;

                }
            }
        }
        if (distanciaX <= 20f)
        {
            andar = false;
            animator.SetBool("DA", andar);
        }
    }


    public void Atacar()
    {
        if (distanciaX <= 20f)
        {
            atacar = true;
            animator.SetBool("andar", andar);
            animator.SetBool("disparar", atacar);
            

           

            if (puedeDisparar && !coroutineStarted)
            {
                StartCoroutine(DispararCoroutine());
                coroutineStarted = true;

            }
        }
        else
        {
            andar = true;
            atacar = true;
            animator.SetBool("DA", true);
        }

    }

    private void Flip()
    {
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<CambioPlayer>().tieneItemPM == false)
        {
            if (collision.gameObject.tag == "Player" && Mathf.Abs(gameObject.transform.position.y - collision.gameObject.transform.position.y) < 3.75f)
            {
                if (Mathf.Abs(gameObject.transform.position.x - collision.gameObject.transform.position.x) < 2.25f)
                {
                    float alturaSalto = 0.2f;

                    Personaje.hit = true;
                    collision.transform.Translate(Vector3.up * alturaSalto);
                    gameObject.GetComponent<EnemigoGrande>().TomarDaño(25);

                }
                else
                {
                    collision.gameObject.GetComponent<CambioPlayer>().morir();
                }
            }
        }

        if (collision.gameObject.GetComponent<CambioPlayer>().tieneItemPM == false)
        {
            if (collision.gameObject.tag == "PlayerItem" && Mathf.Abs(gameObject.transform.position.y - collision.gameObject.transform.position.y) < 3.75f)
            {
                if (Mathf.Abs(gameObject.transform.position.x - collision.gameObject.transform.position.x) < 2.25f)

                {
                    float alturaSalto = 0.2f;

                    Personaje.hit = true;
                    collision.transform.Translate(Vector3.up * alturaSalto);
                    gameObject.GetComponent<EnemigoGrande>().TomarDaño(25);
                }
                else
                {
                    collision.gameObject.GetComponent<CambioPlayer>().CambioNormal();
                }
            }
        }
    }

    public void Giro()

    {
        Vector3 scale = transform.localScale;
        float objetivoPosX = objetivo.transform.position.x;
        float objetoPosX = transform.position.x;

        if (objetivoPosX < objetoPosX)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = -Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }
}

