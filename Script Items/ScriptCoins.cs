using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCoins : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.tag == "Player")
        {
            GameController.SumaMoneda();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "PlayerItem")
        {
            GameController.SumaMoneda();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "ItemGatoAyuda")
        {
            GameController.SumaMoneda();
            Destroy(gameObject);
        }
    }
}
