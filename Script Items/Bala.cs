using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float velocidad;
    private float direccion = 1f;
    public int da�o;
    [SerializeField] private GameObject efectoMuerte;

    private void Update()
    {

        transform.Translate(Vector2.right * velocidad * direccion * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemigosPeque�os"))
        {

            Instantiate(efectoMuerte, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("EnemigoGrande"))
        {
            other.gameObject.GetComponent<EnemigoGrande>().TomarDa�o(da�o);
            Destroy(gameObject);
        }
    }
    public void Inicializar(float direccionPersonaje)
    {
        direccion = direccionPersonaje;
    }

}
