using System;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float damage;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * -speed;
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Hace daño al Player
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
        
        Destroy(gameObject);
    }
}
