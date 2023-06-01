using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GatoAyuda : MonoBehaviour
{

    private GameObject player;
    private GameObject coin;
    private bool seguirC;
    public int speed;
    public float flyingHeight;
    public float distanceToPlayer;
    public float distanceOffset;
    public LayerMask suelo;

    private Animator animator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        coin = GameObject.FindGameObjectWithTag("Coin");
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        coin = GameObject.FindGameObjectWithTag("Coin");
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (!seguirC && distanceToPlayer < 5) // Si el objeto "Coin" está dentro del campo de visión del jugador, empieza a seguirlo
        {
            if (coin != null)
            {
                seguirC = true;
            }
            else
            {
                seguirC = false;
            }
        }

        if (seguirC)
        {
            if (coin != null)
            {
                Vector2 targetPosition = new Vector2(coin.transform.position.x, coin.transform.position.y + flyingHeight);
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
            else
            {
                seguirC = false;
            }
        }
        else
        {
            MoveWithDistanceOffset();
        }
    }

    private void MoveWithDistanceOffset()
    {
        Vector2 targetPosition = new Vector2(player.transform.position.x, player.transform.position.y + flyingHeight);
        Vector2 direction = targetPosition - (Vector2)transform.position;
        float distance = direction.magnitude;

        if (distance > distanceOffset)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            GameController.SumaMoneda();
            Destroy(collision.gameObject);
        }
    }
}

