using System;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    //[SerializeField]
    //private int id;
    [SerializeField]
    private Animator anim;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        
        /*for (int i = 0; i < GameManager.instance.scenarioData.DoorOpen.Count; i++) 
        {
            if (GameManager.instance.scenarioData.DoorOpen[id] == true)
            {
                OpenDoor();
            }
        }*/
        
        if (GameManager.instance.scenarioData.DoorOpen == true)
        {
            OpenDoor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        Debug.Log("Palanca");
        anim.SetTrigger("Activate");
        GameObject.Find("Puerta").gameObject.GetComponent<Animator>().SetBool("Open", true);
        GameObject.Find("Puerta").gameObject.GetComponent<Collider2D>().enabled = false;
        GameManager.instance.scenarioData.DoorOpen = true;
    }
}
