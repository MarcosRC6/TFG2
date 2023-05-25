using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{

    public GameObject bloque;
    public GameObject item;
    public Transform spawnItem;
    public GameObject bloqueUsado;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.contacts[0].normal.y > 0.5)
        {
            bloqueUsado.SetActive(true); 
            bloqueUsado.transform.position = transform.position; // Igualar la posición
            bloqueUsado.transform.localScale = transform.localScale; // Igualar la escala
            if (item != null)
            {
                Instantiate(item, spawnItem.position, spawnItem.rotation);
            }
            Destroy(bloque);
        }

        if (collision.gameObject.CompareTag("PlayerItem") && collision.contacts[0].normal.y > 0.5)
        {
            bloqueUsado.SetActive(true);
            bloqueUsado.transform.position = transform.position; // Igualar la posición
            bloqueUsado.transform.localScale = transform.localScale; // Igualar la escala
            if (item != null)
            {
                Instantiate(item, spawnItem.position, spawnItem.rotation);
            }
            Destroy(bloque);
        }
    }
}
