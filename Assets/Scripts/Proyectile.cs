using UnityEngine;

public class Proyectile : MonoBehaviour
{
    public float speed = 10f;
    public float force = 500f;
    public float lifeTime = 2f;
    public int damage = 20;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.left * speed;

        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CHOQUE CON: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("IMPACTÓ AL PLAYER");

            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if (player != null)
            {
                // Dirección del empuje
                Vector2 knockbackDirection =
                    (collision.transform.position - transform.position).normalized;

                player.KnockBack(knockbackDirection, force);

                player.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}