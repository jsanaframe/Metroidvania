using System;
using UnityEngine;

public class ObjetoRecolectableController : MonoBehaviour
{
    [SerializeField] 
    private bool healthGema, manaGema;
    private LevelManager lm;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (healthGema == true)
            {
                GameManager.instance.gameData.HealthPotionsCount += 1;
                lm.UpdatehealthPocionesText();
            }
            else if (manaGema == true)
            {
                GameManager.instance.gameData.ManaPotionsCount += 1;
                lm.UpdateManaPocionesText();
            }
            Destroy(gameObject);
        }
    }
}
