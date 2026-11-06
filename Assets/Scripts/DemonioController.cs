using UnityEngine;

public class DemonioController : EnemyController
{
    [SerializeField] private GameObject fuegoPrefab;
    [SerializeField] private Transform fuegoSpawnPoint;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
    
    public void DemonioFuego()
    {
        Instantiate(fuegoPrefab, fuegoSpawnPoint.position, fuegoSpawnPoint.rotation);
    }
}
