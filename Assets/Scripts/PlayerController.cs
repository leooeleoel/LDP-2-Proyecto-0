using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerJumpForce = 4f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;

    private int index = 0;

    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;

    private bool isKnockedBack = false;

    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movimiento normal solo si no está siendo empujado
        if (!isKnockedBack)
        {
            float movimiento = Input.GetAxis("Horizontal");

            myrigidbody2D.linearVelocity = new Vector2(
                movimiento * playerSpeed,
                myrigidbody2D.linearVelocity.y
            );
        }

        // Salto
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isKnockedBack)
        {
            myrigidbody2D.linearVelocity = new Vector2(
                myrigidbody2D.linearVelocity.x,
                playerJumpForce
            );
        }
    }


    // Esta función será llamada por el proyectil
    public void KnockBack(Vector2 direction, float force)
    {
        isKnockedBack = true;

        // Quita la velocidad anterior para que el golpe sea consistente
        myrigidbody2D.linearVelocity = Vector2.zero;

        // Aplica el empuje
        myrigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);

        StartCoroutine(ResetKnockBack());
    }


    IEnumerator ResetKnockBack()
    {
        yield return new WaitForSeconds(0.3f);

        isKnockedBack = false;
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