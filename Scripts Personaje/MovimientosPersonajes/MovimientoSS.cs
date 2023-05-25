using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoSS : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [Header("Movimiento")]
    [Header("Salto")]
    [Header("Animacion")]

    private float movimientoHorizontal = 0f;
    [SerializeField] private float velocidadDeMovimiento;
    [SerializeField] private float suavizadoDeMovimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;
    private Animator animator;

    [SerializeField] private float fuerzaSalto;
    [SerializeField] private LayerMask esSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionCaja;
    [SerializeField] private bool enSuelo;
    private bool salto = false;
    private bool agachado = false;

    [SerializeField] private float gravedadNormal = 4f;
    [SerializeField] private float gravedadAgachado = 6f;
    [SerializeField] private float gravedadSA = 6f;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        //--------------------------------------------MOVIMIENTO---------------------------------------------//

        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;
        bool corriendo = Mathf.Abs(movimientoHorizontal) > 1000f;

        // Agacharse
        if (Input.GetButtonDown("Agacharse"))
        {
            agachado = true;
            velocidadDeMovimiento = 0f; // Detener el movimiento horizontal al agacharse
        }
        else if (Input.GetButtonUp("Agacharse"))
        {
            agachado = false;
            // Restaurar la velocidad de movimiento normal si no está corriendo
            if (!corriendo)
            {
                velocidadDeMovimiento = 1000f;
            }
        }

        //Saltar
        if (Input.GetButtonDown("Jump"))
        {
            salto = true;

            if (agachado && Input.GetButtonDown("Jump"))
            {
                salto = true;
                rb2D.gravityScale = gravedadSA;
            }

        }

        // Correr
        if (Input.GetButton("Horizontal") && Input.GetKey(KeyCode.LeftShift))
        {
            // Correr si no está agachado
            if (!agachado)
            {
                corriendo = true;
                velocidadDeMovimiento = 1350f;
            }
        }
        else if (Input.GetButtonUp("Horizontal") && !Input.GetKey(KeyCode.LeftShift))
        {
            // Andar si no está agachado
            if (!agachado)
            {
                corriendo = false;
                velocidadDeMovimiento = 1000f;
            }
        }

        // Actualizar parámetros de animación

        animator.SetBool("Andando", Mathf.Abs(movimientoHorizontal) >= 0.1f && Mathf.Abs(movimientoHorizontal) <= 1000f);
        animator.SetBool("Corriendo", corriendo);
    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionCaja, 0f, esSuelo);
        animator.SetBool("EnSuelo", enSuelo);
        animator.SetBool("Agachado", agachado);
        // Mover
        Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);

        salto = false;

        bool corriendo = Mathf.Abs(rb2D.velocity.x) >= 1350f || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        //Si no esta en el suelo
        if (!enSuelo)
        {
            // Y está agachado
            if (agachado)
            {
                // Aumento de gravedad
                rb2D.gravityScale = gravedadAgachado;
            }
            else
            {
                // Gravedad normal
                rb2D.gravityScale = gravedadNormal;
            }
        }

    }

    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);


        // si está agachado desactivar el movimiento horizontal 
        if (agachado)
        {
            mover = 0f;
        }

        //Movimientos de giro 
        if (mover > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (mover < 0 && mirandoDerecha)
        {
            Girar();
        }

        //Si esta en el suelo y salta
        if (enSuelo && saltar)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaSalto));
        }

    }
    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(controladorSuelo.position, dimensionCaja);
    }
}
