using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaBowser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float velocidad;
    private float direccion = 1f;
    private GameObject objetivo;
    private GameObject controlador;
    float dir = 0;

    private void Start()
    {
        controlador = GameObject.FindWithTag("EnemigoGrande");

        objetivo = GameObject.FindWithTag("Player");

        if (objetivo == null)
            objetivo = GameObject.FindWithTag("PlayerItem");
        dir = Mathf.Sign(controlador.transform.localScale.x);
    }

    private void Update()
    {
        controlador = GameObject.FindWithTag("EnemigoGrande");

        objetivo = GameObject.FindWithTag("Player");

        if (objetivo == null)
            objetivo = GameObject.FindWithTag("PlayerItem");

        Giro();

        transform.Translate(Vector2.left * velocidad * direccion * Time.deltaTime * dir);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<CambioPlayer>().morir();
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("PlayerItem"))
        {
            other.gameObject.GetComponent<CambioPlayer>().CambioNormal();
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("suelo"))
        {
            Destroy(gameObject);
        }
    }
    public void Inicializar(float direccionPersonaje)
    {
        direccion = direccionPersonaje;

    }

    public void Giro()

    {
        Vector3 scale = transform.localScale;
        float objetivoPosX = objetivo.transform.position.x;
        float objetoPosX = controlador.transform.position.x;

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
