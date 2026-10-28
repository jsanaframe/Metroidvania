using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    
    private int jumpCount;
    private int comboCount;
    
    private bool canMove = true;

    private Rigidbody2D rb;
    private Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == false)
        {
            return;
        }
        
        //Mover
        float inputX = Input.GetAxis("Horizontal");
        if (comboCount > 0)
        {
            inputX = 0;
        }
        rb.linearVelocityX = speed *  inputX;
        
        //Rotación
        if (inputX > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (inputX < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
        //Animación
        //Correr
        if (inputX != 0)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
        
        Collider2D[] temp = Physics2D.OverlapCircleAll(transform.position, 0.01f);
        bool isGrounded = false;
        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i].tag == "Ground")
            {
                isGrounded = true;
                
            }
        }

        if (isGrounded == true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Falling", false);
            jumpCount = 0;
            //Debug.Log("Toco Suelo");
        }
        else
        {
            if (jumpCount == 0)
            {
                jumpCount++;
            }
            animator.SetBool("Falling", true);
        }

        //Saltar
        if (Input.GetButtonDown("Jump") && jumpCount < GameManager.instance.gameData.MaxJumps && comboCount == 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
            animator.SetBool("Jump", true);
            jumpCount++;
        }

        //Ataque
        if (Input.GetButtonDown("Attack") && isGrounded == true)
        {
            comboCount = Mathf.Clamp(comboCount + 1, 0, 2);
            animator.SetInteger("Combo", comboCount);
        }

        
    }
    
    public void FinishAttack1()
    {
        if (comboCount <= 1)
        {
            comboCount = 0;
            animator.SetInteger("Combo", comboCount);
        }
    }
    
    public void FinishAttack2()
    {
        comboCount = 0;
        animator.SetInteger("Combo", comboCount);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().TakeDamage(GameManager.instance.gameData.Damage);
            //Llamaremos a la funcion del enemigo para recibir daño
            //Debug.Log("Funciona");
        }
    }

    public void TakeDamage(float _damage)
    {
        GameManager.instance.gameData.Life -= _damage;
        if (GameManager.instance.gameData.Life <= 0 && canMove == true)
        {
            //MUERTE
            animator.SetTrigger("Dead");
            canMove = false;
            rb.linearVelocityX = 0;
        }
        else if (GameManager.instance.gameData.Life > 0)
        {
            //HIT
            animator.SetTrigger("Hit");
            comboCount = 0;
            animator.SetInteger("Combo", comboCount);
        }
    }
}
