using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float distanceToAttack;
    [SerializeField]
    protected float attackRate;
    [SerializeField]
    protected float damage;
    [SerializeField]
    protected float life;
    protected float timePass;

    protected bool following;
    protected bool attacking;
    
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
        timePass += Time.deltaTime;
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
                //Attack();
                //Invoke("Attack", 1.2f); //Lo hace infinito
                //InvokeRepeating("Attack", 1f, 2f); //Lo hace infinto
                attacking = true;
            }
            else
            {
                attacking = false;
            }
        }

        if (attacking == true)
        {
            if (timePass >= attackRate)
            {
                Attack();
                timePass = 0;
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
            Debug.Log("Hacer daño al player");
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
        /*if (other.tag == "Player")
        {
            player = other.transform;
            following = true;
        }*/
    }

    public void SetPlayer(Transform _player)
    {
        player = _player;
        following = true;
    }

    public void TakeDamage(float _damage)
    {
        life -= _damage;
        if (life <= 0 && following)
        {
            animator.SetTrigger("Dead");
            following = false;
            rb.linearVelocityX = 0;
            rb.bodyType = RigidbodyType2D.Kinematic;
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
        else if (life > 0)
        {
            animator.SetTrigger("Hit");
        }
    }
    
    /*public void SetPlayerExit(Transform _player)
    {
        player = _player;
        following = false;
    }*/
}
