using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveStone : MonoBehaviour
{
    [SerializeField]
    private GameObject arrow;
    
    [SerializeField]
    private ParticleSystem particles;
    
    [SerializeField]
    private SpriteRenderer brilloPiedra;
    [SerializeField]
    private float animSpeed;


    private void Start()
    {
        StartCoroutine(BrilloPiedra());
    }
    
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
                particles.Play();
                arrow.SetActive(false);
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

    IEnumerator BrilloPiedra()
    {
        float t = 0;
        
        while (t < 1)
        {
            t += Time.deltaTime * animSpeed;
            float alpha = Mathf.Lerp(0, 1, t);
            Color tempColor = brilloPiedra.color;
            tempColor.a = alpha;
            brilloPiedra.color = tempColor;
            yield return null;
        }
        
        while (t > 0)
        {
            t -= Time.deltaTime * animSpeed;
            float alpha = Mathf.Lerp(0, 1, t);
            Color tempColor = brilloPiedra.color;
            tempColor.a = alpha;
            brilloPiedra.color = tempColor;
            yield return null;
        }
        
        StartCoroutine(BrilloPiedra());
    }
    
}