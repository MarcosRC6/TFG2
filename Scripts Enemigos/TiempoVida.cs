using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoVida : MonoBehaviour
{
    [SerializeField] private float tiempodevida;
    void Start()
    {
        Destroy(gameObject, tiempodevida);
    }
}
