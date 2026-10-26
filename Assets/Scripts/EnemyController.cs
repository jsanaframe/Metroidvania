using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    protected float speed;

    [SerializeField]
    protected float distanceToAttack;

    protected bool following;
    protected Transform player;
    protected Rigidbody2D rb;
    protected Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    protected void Update()
    {
        //Movimiento
        if (following == true)
        {
            animator.SetBool("Run", true);
            Vector3 direction = player.position - transform.position;
            if (direction.x  < 0) //hacia la izquierda
            {
                rb.linearVelocityX = -speed;
                transform.eulerAngles = Vector3.zero;
            }
            else //hacia la derecha
            {
                rb.linearVelocityX = speed;
                transform.eulerAngles = new Vector3(0, 180, 0);
            }

            if (Mathf.Abs(direction.x) <= distanceToAttack)
            {
                //Que ataque
                rb.linearVelocityX = 0;
                animator.SetBool("Run", false);
                Attack();
            }
        }
    }

    protected void Attack()
    {
        animator.SetTrigger("Attack");
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.transform;
            following = true;
        }
    }
}
