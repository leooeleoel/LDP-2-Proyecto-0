using UnityEngine;

public class Proyectile : MonoBehaviour
{
    public float speed = 10f;
    public float force = 10f;
    public float lifeTime = 2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.left * speed;

        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                Vector2 knockbackDirection =
                    (collision.transform.position - transform.position).normalized;

                knockbackDirection.y = 0;

                player.KnockBack(knockbackDirection, force);
            }

            Destroy(gameObject);
        }
    }
}