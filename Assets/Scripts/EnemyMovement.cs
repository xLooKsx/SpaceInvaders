using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float MovementDirectionChangeTimer;
    public bool MovementDirectionIsRight = true;

    private float movementSpeed = 1;
    private Rigidbody2D myRigidbody2D;
    public float currentTimeForDirectionChange;
    private bool changeMovementDirection = false;

    void Start()
    {
        currentTimeForDirectionChange = 0;
        myRigidbody2D = this.GetComponent<Rigidbody2D>();
        StartMovement();
    }

    // Update is called once per frame
    void Update()
    {
        if (changeMovementDirection)
        {
            StartMovement();
            changeMovementDirection = false;
            currentTimeForDirectionChange = 0;
        }
        CheckTimerForDirectinChange();
    }

    private void CheckTimerForDirectinChange()
    {
        if (currentTimeForDirectionChange >= MovementDirectionChangeTimer)
        {
            changeMovementDirection = true;
            MovementDirectionIsRight = !MovementDirectionIsRight;
        }
        else
        {
            currentTimeForDirectionChange += Time.deltaTime;
        }
    }

    private void StartMovement()
    {
        Vector2 horizontalMovement = DecideMovemntDirection();
        myRigidbody2D.velocity = horizontalMovement * movementSpeed;
    }

    private Vector2 DecideMovemntDirection()
    {
        Vector2 horizontalMovement;
        if (MovementDirectionIsRight)
        {
            horizontalMovement = Vector2.right;
        }
        else
        {
            horizontalMovement = Vector2.left;
        }

        return horizontalMovement;
    }
}
