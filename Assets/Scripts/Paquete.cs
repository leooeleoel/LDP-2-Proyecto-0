using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public int healAmount = 20;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                player.Heal(healAmount);
            }

            Destroy(gameObject);
        }
    }
}