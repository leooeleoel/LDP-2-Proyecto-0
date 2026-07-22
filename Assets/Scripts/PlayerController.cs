using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float playerJumpForce = 4f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    private int index = 0;

    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;
    //public GameObject Bullet;
    //public GameManager myGameManager;



    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        //StartCoroutine(WalkCoRoutine());
    //    myGameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimiento = Input.GetAxis("Horizontal");

        myrigidbody2D.linearVelocity = new Vector2(
            movimiento * playerSpeed,
            myrigidbody2D.linearVelocity.y
        );

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            myrigidbody2D.linearVelocity = new Vector2(
                myrigidbody2D.linearVelocity.x,
                playerJumpForce
            );
        }
    }
    // if (Input.GetKeyDown(KeyCode.E))
    //   {
    //     Instantiate(Bullet, transform.position, Quaternion.identity);
    //}


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