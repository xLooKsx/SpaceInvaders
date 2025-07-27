using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float MovementSpeed;

    public bool isDownToTop;
    private bool originIsPlayer;
    private Rigidbody2D myRigidbody2D;
    private GameManager gameManagerScript;

    void Start()
    {
        myRigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDownToTop)
        {
            myRigidbody2D.velocity = Vector2.up * MovementSpeed;
        }
        else
        {
            myRigidbody2D.velocity = Vector2.up * -MovementSpeed;
        }
    }

    public void SetIsDownToTop(bool value)
    {
        this.isDownToTop = value;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && originIsPlayer)
        {
            GameObject.Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Player") && !originIsPlayer)
        {
            GameObject.Destroy(collision.gameObject);
            gameManagerScript.GameOver();
        }
        else if (collision.CompareTag("Defenses"))
        {
            collision.gameObject.GetComponent<DefenseBehavior>().GotHit();
        }
    }

    public void SetGameManagerScript(GameManager gameManager)
    {
        this.gameManagerScript = gameManager;
    }

    public void SetOriginIsPlayer(bool originIsPlayer)
    {
        this.originIsPlayer = originIsPlayer;
    }

}
