using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}