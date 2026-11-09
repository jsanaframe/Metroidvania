using System;
using UnityEngine;

public class Gema : MonoBehaviour
{
    [SerializeField]
    private string id;
    
    public string message;
    
    [SerializeField]
    private ParticleSystem particles;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        switch (id)
        {
            case "DobleJump":
            {
                if (GameManager.instance.gameData.MaxJumps > 1)
                {
                    Destroy(gameObject);
                }
                break;
            }
            case "Dash":
            {
                break;
            }
            case "MagicAttack":
            {
                break;
            }
            default:
            {
                break;
            }
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
            switch (id)
            {
                case "DobleJump":
                {
                    Debug.Log("DobleJump");
                    GameManager.instance.gameData.MaxJumps = 2;
                    break;
                }
                case "Dash":
                {
                    break;
                }
                case "MagicAttack":
                {
                    break;
                }
                default:
                {
                    break;
                }
            }
            particles.Play();
            Time.timeScale = 0;
        }
    }
}
