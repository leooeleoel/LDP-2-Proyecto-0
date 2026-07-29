using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float playerJumpForce = 4f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;

    private int index = 0;

    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;

    private bool isKnockedBack = false;

    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthBar;

    public int maxJumps = 2;
    private int jumpCount = 0;

    public Transform groundCheck;
    public float groundCheckRadius = 0.4f;
    public LayerMask groundLayer;

    private bool isGrounded;

    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;

        if (healthBar != null) { 
        
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
        else
        {
            Debug.LogError("NO asignaste la barra de vida en el Inspector");
        }
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            jumpCount = 0; 
        }
        if (!isKnockedBack)
        {
            float movimiento = Input.GetAxis("Horizontal");

            myrigidbody2D.linearVelocity = new Vector2(
                movimiento * playerSpeed,
                myrigidbody2D.linearVelocity.y
            );
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < maxJumps)
        {
            myrigidbody2D.linearVelocity = new Vector2(
                myrigidbody2D.linearVelocity.x,
                playerJumpForce
            );

            jumpCount++;
        }

    }
    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        Debug.Log("Curado. Vida actual: " + currentHealth);
    }
    public void KnockBack(Vector2 direction, float force)
    {
        isKnockedBack = true;

        myrigidbody2D.linearVelocity = Vector2.zero;

        myrigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);

        StartCoroutine(ResetKnockBack());
    }

    IEnumerator ResetKnockBack()
    {
        yield return new WaitForSeconds(0.3f);
        isKnockedBack = false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        Debug.Log("Vida actual: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("El jugador murió");
        Destroy(gameObject);
    }

    IEnumerator WalkCoRoutine()
    {
        yield return new WaitForSeconds(0.05f);

        mySpriteRenderer.sprite = mySprites[index];

        index++;

        if (index == 6)
        {
            index = 0;
        }

        StartCoroutine(WalkCoRoutine());
    }
}