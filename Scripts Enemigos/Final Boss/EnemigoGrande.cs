using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoGrande : MonoBehaviour
{
    [SerializeField] private float vida = 100;
    public GameObject BanderaNS;
    [SerializeField] private GameObject efectoMuerte;

    private void Start()
    {
        BanderaNS.gameObject.SetActive(false);
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;

        if(vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        Instantiate(efectoMuerte, transform.position, Quaternion.identity);
        Destroy(gameObject);
        BanderaNS.gameObject.SetActive(true);
    }
}
