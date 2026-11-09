using System;
using UnityEngine;

public class Palanca : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Palanca");
            anim.SetTrigger("Activate");
            GameObject.Find("Puerta").gameObject.GetComponent<Animator>().SetBool("Open", true);
        }
    }
}
