using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RomperCofreController : MonoBehaviour
{
    [SerializeField]
    private GameObject healthGema, manaGema;

    [SerializeField]
    private GameObject cofreRotoPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            Debug.Log("Arma choca cofre");
            ElegirOpcionCofre(transform.position);
            GameObject clone = Instantiate(cofreRotoPrefab, transform.position, transform.rotation);
            for (int i = 0; i < clone.transform.childCount; i++)
            {
                clone.transform.GetChild(i).GetComponent<Rigidbody2D>().isKinematic = false;
                clone.transform.GetChild(i).GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f,1f),Random.Range(0f,1f)) * 300);
            }
            Destroy(clone, 0.5f);
            Destroy(gameObject);
        }
    }
    
    void ElegirOpcionCofre(Vector3 posicion)
    {
        // Genera un número entero aleatorio entre 1 y 5
        // (El número 6 es exclusivo, por lo que nunca saldrá)
        int numeroAleatorio = Random.Range(1, 6);
        
        GameObject objetoAClonar = null;
        
        // Evaluamos el número obtenido con un switch
        switch (numeroAleatorio)
        {
            case 1:
                objetoAClonar = healthGema;
                Debug.Log("Salió Health");
                break;

            case 2:
                objetoAClonar = manaGema;
                Debug.Log("Salió Mana");
                break;

            case 3:
                //objetoAClonar = healthGema;
                Debug.Log("No salio nada");
                break;

            case 4:
                //objetoAClonar = healthGema;
                Debug.Log("No salio nada");
                break;

            case 5:
                //objetoAClonar = healthGema;
                Debug.Log("No salio nada");
                break;

            default:
                Debug.Log("No salio nada");
                break;
        }
        
        if (objetoAClonar != null)
        {
            GameObject clone = Instantiate(objetoAClonar, posicion, Quaternion.identity);
            //Destroy(clone,1);
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
