using System;
using System.Collections;
using UnityEngine;

public class TrampillaController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Detected en Trampilla");
            Invoke("ActivarTrampa", 0.5f);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Detected en Trampilla");
            Invoke("ActivarTrampa", 0.5f);
        }
    }*/

    void ActivarTrampa()
    {
        Debug.Log("Trampa Activada despres de 0,5s");
        anim.SetBool("Activate", true);
        Invoke("CerrarTrampa", 2f);
    }

    void CerrarTrampa()
    {
        anim.SetBool("Activate", false);
    }
}
