using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{

    public GameObject bloque;
    public GameObject item;
    public Transform spawnItem;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.contacts[0].normal.y > 0.5)
        {
            if (item != null)
            {
                Instantiate(item, spawnItem.position, spawnItem.rotation);
            }
            Destroy(bloque);
        }
    }
}
