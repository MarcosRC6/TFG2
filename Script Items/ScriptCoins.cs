using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCoins : MonoBehaviour
{
    public AudioSource SonidoMoneda;

    public void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.tag == "Player")
        {
            SoundCoin();
            GameController.SumaMoneda();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "PlayerItem")
        {
            SoundCoin();
            GameController.SumaMoneda();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "ItemGatoAyuda")
        {
            SoundCoin();
            GameController.SumaMoneda();
            Destroy(gameObject);
        }
    }

    public void SoundCoin()
    {
        SonidoMoneda.Play();
    }
}
