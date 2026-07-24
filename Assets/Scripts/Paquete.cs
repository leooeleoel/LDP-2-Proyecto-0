using UnityEngine;

public class HealthPack : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TOCADO");

        if (collision.CompareTag("Player"))
        {
            Debug.Log("DESTRUYENDO");
            Destroy(this.gameObject, 0.1f);
        }
    }
}