using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioPlayer : MonoBehaviour
{
    [SerializeField] private float fuerzaSalto;

    public GameObject JugadorCh;
    public GameObject JugadorSM;
    public GameObject JugadorSS;
    public GameObject Jugador;
    public GameObject AnimacionPB;
    public GameObject AnimacionPM;
    public GameObject GatoAyuda;

    [SerializeField] public AudioSource audioCoin;
    public GameObject gameover;


    private Rigidbody2D rb2D;
    private Animator animator;

    public bool hit = false;
    public bool tieneItemPB = false;
    public bool tieneItemGA = false;
    public bool tieneItemPM = false;

    private GameObject jugadorActual;
    public bool normal;
    public bool muerte;
    


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        jugadorActual = gameObject;
        muerte = false;
        animator = GetComponent<Animator>();
        if (jugadorActual.CompareTag("Player"))
        {
            normal = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb2D = GetComponent<Rigidbody2D>();

        if (jugadorActual.CompareTag("Player"))
        {
            normal = true;
        }

        jugadorActual = gameObject;

        if (muerte)
        {
            morir();
        }

        if (hit)
        {
            rb2D.AddForce(new Vector2(0f, fuerzaSalto));
            hit = false;
        }

    }

    public void CambioNormal()
    {
        float distanciaSalto = 5f;
        Vector3 direccionSalto = new Vector3(0, 1, 0); // Dirección diagonal hacia arriba y a la izquierda
        transform.Translate(direccionSalto.normalized * distanciaSalto);

        jugadorActual.SetActive(false);

        Jugador.transform.position = jugadorActual.transform.position;
        Jugador.SetActive(true);

        jugadorActual = Jugador;
        normal = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ItemSS"))
        {
            jugadorActual.SetActive(false);

            JugadorSS.transform.position = jugadorActual.transform.position;
            JugadorSS.SetActive(true);

            jugadorActual = JugadorSS;
            normal = false;

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("ItemSM"))
        {
            jugadorActual.SetActive(false);

            JugadorSM.transform.position = jugadorActual.transform.position;
            JugadorSM.SetActive(true);

            jugadorActual = JugadorSM;
            normal = false;

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("ItemCH"))
        {
            jugadorActual.SetActive(false);

            JugadorCh.transform.position = jugadorActual.transform.position;
            JugadorCh.SetActive(true);

            jugadorActual = JugadorCh;
            normal = false;

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("ItemPB"))
        {
            tieneItemPB = true;
            StartCoroutine(DuracionItemPB(15f));
        }

        if (collision.gameObject.CompareTag("ItemPM"))
        {
            tieneItemPM = true;
            StartCoroutine(DuracionItemPM(20f));
        }

        if (collision.gameObject.CompareTag("ItemGatoAyuda"))
        {
            tieneItemGA = true;
            GatoAyuda.gameObject.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            audioCoin.Play();
        }

        if (collision.gameObject.CompareTag("EnemigosPequeños"))
        {
            if (tieneItemPM)
            {
                collision.gameObject.GetComponent<Collider2D>().isTrigger = true;
                Destroy(collision.gameObject);
            }
        }
    }

    private IEnumerator DuracionItemPB(float duration)
    {
        AnimacionPB.SetActive(true);
        yield return new WaitForSeconds(duration);
        AnimacionPB.SetActive(false);
        tieneItemPB = false;
    }

    private IEnumerator DuracionItemPM(float duration)
    {
        AnimacionPM.SetActive(true);
        yield return new WaitForSeconds(duration);
        AnimacionPM.SetActive(false);
        tieneItemPM = false;
    }

    public void morir()
    {
        muerte = true;
        jugadorActual.GetComponent<Collider2D>().isTrigger = true;
        jugadorActual.GetComponent<CapsuleCollider2D>().isTrigger = true;
        animator.SetBool("Muerto", muerte);
        float distanciaSalto = 1.5f;
        Vector3 direccionSalto = new Vector3(0, 3, 0); // Dirección diagonal hacia arriba y a la izquierda
        transform.Translate(direccionSalto.normalized * distanciaSalto);
        StartCoroutine(EsperarAnimacionYActivarDesactivar());
        muerte = false;

    }
    private IEnumerator EsperarAnimacionYActivarDesactivar()
    {
        // Esperar un tiempo suficiente para que la animación termine
        yield return new WaitForSeconds(0.5f); // Reemplaza 'tiempoDeEspera' con el valor apropiado

        ActivarDesactivar();
    }


    public void ActivarDesactivar()
    {

        gameover.SetActive(true);

    }
}