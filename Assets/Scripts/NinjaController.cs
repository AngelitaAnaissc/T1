using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    
    public float fuerzaSalto = 5;
    public float velocidad = 1;


    private bool EstaMuerto = false;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;

    private const int ANIMATION_CORRER = 1;
    private const int SALTAR = 2;
    private const int MORIR = 3;
    private const int QUIETO = 0;

    private int contador = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (EstaMuerto == false)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Saltar();

                if (contador == 3) { contador = 0; velocidad = velocidad + 3; }
            }
            CambiarAnimacion(ANIMATION_CORRER);
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
            spriteRenderer.flipX = false;
          
        }
        else if (EstaMuerto == true)
        {
            CambiarAnimacion(MORIR);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }


    private void Saltar()
    {
        rb.velocity = Vector2.up * fuerzaSalto;
        CambiarAnimacion(SALTAR);
    }

    private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Zombie_M" | collision.gameObject.tag == "Zombie_F")
        {
            EstaMuerto = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Triguer")
        {
            contador++;
        }
    }
}