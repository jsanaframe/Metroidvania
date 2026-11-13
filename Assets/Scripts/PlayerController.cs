using System.Collections;
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
    private bool cooldownObjeto = false;

    private Rigidbody2D rb;
    private Animator animator;
    private LevelManager lm;
    [SerializeField]
    private GameObject fireballPrefab;
    [SerializeField]
    private Transform fireballSpawnPoint;
    [SerializeField]
    private float fuerza = 10f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
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

        //HardAttack
        if (Input.GetButtonDown("HardAttack") && isGrounded == true)
        {
            animator.SetTrigger("HardAttack");
            canMove = false;
            rb.linearVelocityX = 0;
        }
        
        //Magic
        if (Input.GetButtonDown("Magic") && isGrounded == true)
        {
            if (GameManager.instance.gameData.Mana <= 0)
            {
                return;
            }
            animator.SetTrigger("Magic");
            GameObject clone = Instantiate(fireballPrefab, fireballSpawnPoint.position, fireballSpawnPoint.rotation);
            clone.GetComponent<Rigidbody2D>().AddForce(transform.right * fuerza);
            GameManager.instance.gameData.Mana -= 2;
            lm.UpdateManaBar();
        }
        
        //Utilizar Gema Health
        float inputH = Input.GetAxis("UtilizarGemaH");
        if (inputH > 0 && cooldownObjeto == false && GameManager.instance.gameData.Life != GameManager.instance.gameData.MaxLife && GameManager.instance.gameData.HealthPotionsCount > 0)
        {
            Debug.Log("Tomar pocion vida");
            GameManager.instance.gameData.HealthPotionsCount -= 1;
            GameManager.instance.gameData.Life = Mathf.Clamp(GameManager.instance.gameData.Life + 10, 0, GameManager.instance.gameData.MaxLife);
            StartCoroutine(CoolDown(2f));
            lm.UpdateLifeBar();
            lm.UpdatehealthPocionesText();
            
        }
        
        //Utilizar Gema Mana
        float inputM = Input.GetAxis("UtilizarGemaM");
        if (inputM > 0 && cooldownObjeto == false && GameManager.instance.gameData.Mana != GameManager.instance.gameData.MaxMana && GameManager.instance.gameData.ManaPotionsCount > 0)
        {
            Debug.Log("Tomar pocion Mana");
            GameManager.instance.gameData.ManaPotionsCount -= 1;
            GameManager.instance.gameData.Mana = Mathf.Clamp(GameManager.instance.gameData.Mana + 2, 0, GameManager.instance.gameData.MaxMana);
            StartCoroutine(CoolDown(2f));
            lm.UpdateManaBar();
            lm.UpdateManaPocionesText();
            
        }
        
    }

    IEnumerator CoolDown(float waitTime)
    {
        cooldownObjeto = true;
        Debug.Log("Inicio CoolDown de " + waitTime);
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Acabado CoolDown de " + waitTime);
        cooldownObjeto = false;
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
        lm.UpdateLifeBar();
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
            canMove = true;
            animator.SetInteger("Combo", comboCount);
        }
    }

    public void FinishHardAttack()
    {
        canMove = true;
    }
}
