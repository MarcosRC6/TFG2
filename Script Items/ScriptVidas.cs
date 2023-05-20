using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptVidas : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameController.SumaVida();
            Destroy(gameObject);
        }
    }
}
