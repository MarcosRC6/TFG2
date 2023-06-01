using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaCH : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float velocidad;
    private float direccion = 1f;

    private void Update()
    {

        transform.Translate(Vector2.right * velocidad * direccion * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemigosPequeños"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("EnemigoGrande"))
        {
            other.gameObject.GetComponent<EnemigoGrande>().TomarDaño(20);
            Destroy(gameObject);
        }
    }
    public void Inicializar(float direccionPersonaje)
    {
        direccion = direccionPersonaje;
    }

}
