using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playermovement : MonoBehaviour
{

    public float MovementSpeed;
    public GameObject bulletPrefab;

    private Rigidbody2D myRigidbody2D;


    void Start()
    {
        myRigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckIfPlayerHasShoot();
    }

    void FixedUpdate()
    {

        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float fixedHorizontalMovement = horizontalMovement * MovementSpeed;
        //myRigidbody2D.AddForce(new Vector2(fixedHorizontalMovement, 0));
        myRigidbody2D.velocity = new Vector2(fixedHorizontalMovement, 0);
    }

    private void CheckIfPlayerHasShoot()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateBullet();
        }
    }

    private void CreateBullet()
    {

        Vector2 bulletPosition = new Vector2(this.transform.position.x + -0.25f, -3.30f);

        GameObject bullet = GameObject.Instantiate(bulletPrefab, bulletPosition, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetIsDownToTop(true);
        bullet.GetComponent<Bullet>().SetOriginIsPlayer(true);
    }
}
