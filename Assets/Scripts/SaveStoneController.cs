using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveStone : MonoBehaviour
{
    [SerializeField] private GameObject arrow;

    private void Update()
    {
        if (arrow.activeInHierarchy == true)
        {
            if (Input.GetAxis("Vertical")>0.5f)
            {
                //GUARDAMOS
                Debug.Log("Guardado");
                GameManager.instance.gameData.Scene = SceneManager.GetActiveScene().buildIndex;
                GameManager.instance.gameData.SavePosition = transform.position;
                //curar, recargar pociones etc...
                GameManager.instance.SaveData();
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            Debug.Log("Entro en la piedra");
            arrow.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            Debug.Log("Salgo de la piedra");
            arrow.SetActive(false);
            
        }
        
    }
    
    
    
}