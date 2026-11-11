using System;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            Debug.Log("Colisionado con Mundo");
            anim.SetTrigger("Collision");
            rb.linearVelocityX = 0;
        }

        if (other.tag == "Enemy")
        {
            Debug.Log("Colisionado con Enemigo");
            anim.SetTrigger("Collision");
            rb.linearVelocityX = 0;
            other.gameObject.GetComponent<EnemyController>().TakeDamage(GameManager.instance.gameData.Damage);
        }
    }

    public void DestroyBall()
    {
        Destroy(gameObject);
    }
}
