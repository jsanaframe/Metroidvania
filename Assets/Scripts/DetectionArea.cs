using UnityEngine;

public class DetectionArea : MonoBehaviour
{
    private EnemyController enemy;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy = transform.parent.GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enemy.SetPlayer(other.transform);
        }
    }

    /*private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enemy.SetPlayerExit(other.transform);
            
        }
    }*/
}
