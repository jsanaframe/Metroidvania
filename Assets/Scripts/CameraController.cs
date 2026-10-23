using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    [Tooltip("X = Valor de X Min, Y = Valor de X Max")]
    private Vector2 limitX;
    [SerializeField]
    [Tooltip("X = Valor de Y Min, Y = Valor de Y Max")]
    private Vector2 limitY;
    
    [SerializeField]
    private ParallaxEffect[] parallaxEffects;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float x = Mathf.Clamp(player.position.x + offset.x, limitX.x, limitX.y);
        float y = Mathf.Clamp(player.position.y + offset.y, limitY.x, limitY.y);
        float z = player.position.z +  offset.z;
        
        transform.position = new Vector3(x, y, z);
        
        //Actualizar la posicion del parallax
        /*foreach (ParallaxEffect temp in parallaxEffects)
        {
            temp.UpdateParallaxEffects();
        }*/

        for (int i = 0; i < parallaxEffects.Length; i++)
        {
            parallaxEffects[i].UpdateParallaxEffects();
        }
    }
}
