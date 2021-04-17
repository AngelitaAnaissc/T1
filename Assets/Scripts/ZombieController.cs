using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    // Start is called before the first frame update

    public float velocidad = 5;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()//Se ejecuta la primera ves que es instanciado el objeto, la primera ves que aparece el jugador en escena
    {
        Debug.Log("Esto se crea una unica vez");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
            spriteRenderer.flipX = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Ninja")
        {
            velocidad = 0;
        }
    }
}