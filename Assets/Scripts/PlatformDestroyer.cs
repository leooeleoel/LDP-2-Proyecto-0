using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public float destroyX = -20f;

    void Update()
    {
        Debug.Log(transform.name + " X: " + transform.position.x);

        if (transform.position.x < destroyX)
        {
            Debug.Log("DESTRUYENDO: " + gameObject.name);
            Destroy(gameObject);
        }
    }
}