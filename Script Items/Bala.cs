using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float velocidad;
    [SerializeField] private float da�o;
    private float direccion = 1f;

    private void Update()
    {

        transform.Translate(Vector2.right * velocidad * direccion * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemigosPeque�os"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("EnemigosGrandes"))
        {
            //other.GetComponent<EnemigoGrande>().TomarDa�o(da�o);
        }
    }

    public void Inicializar(float direccionPersonaje)
    {
        direccion = direccionPersonaje;
    }

}
