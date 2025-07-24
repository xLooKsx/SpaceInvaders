using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float MovementSpeed;

    public bool isDownToTop;
    private Rigidbody2D myRigidbody2D;

    void Start()
    {
        myRigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isDownToTop){
            Debug.Log("Atirando para cima");
            myRigidbody2D.velocity = Vector2.up * MovementSpeed;
        } else {
            Debug.Log("Atirando para baixo");            
            myRigidbody2D.velocity = Vector2.up * -MovementSpeed;
        }                
    }

    public void SetIsDownToTop(bool value) {
        this.isDownToTop = value;
    }

}
