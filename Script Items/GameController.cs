using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    static GameController current;
    static GameController current2;
    [SerializeField] private TextMeshProUGUI contadorMonedas;
    [SerializeField] private TextMeshProUGUI contadorVidas;

    private int vidas = 5;
    private int monedas =0;

    private void Awake()
    {
        if (current != null && current != this)
        {
            Destroy(gameObject);
            return;
        }
        current = this;
        DontDestroyOnLoad(gameObject);

        if (current2 != null && current2 != this)
        {
            Destroy(gameObject);
            return;
        }
        current2 = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void SumaMoneda()
    {
        current.monedas++;
        if(current.monedas < 10)
        {
            current.contadorMonedas.text = "0" + current.monedas;

        }
        else
        {
            current.contadorMonedas.text = current.monedas.ToString();
        }

        if (current.monedas == 99)
        {
            current.monedas = 0; // Reinicia el contador de monedas a 0
            current.contadorMonedas.text = "00";

            SumaVida(); // Suma 1 al contador de vidas
        }
    }

    public static void SumaVida()
    {
        current2.vidas++;
        if (current2.vidas < 10)
        {
            current2.contadorVidas.text = "0" + current2.vidas;

        }
        else
        {
            current2.contadorVidas.text = current2.vidas.ToString();
        }
    }
    public static void RestarVidas()
    {
        if (current2.vidas != 0)
        {

            current2.vidas--;

            if (current2.vidas < 10)
            {
                current2.contadorVidas.text = "0" + current2.vidas;
            }
            else
            {
                current2.contadorVidas.text = current2.vidas.ToString();
            }
        }
    }
}
