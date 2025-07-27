using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBehavior : MonoBehaviour
{

    public int amountOfLife;

    public void GotHit()
    {
        amountOfLife--;
        if (amountOfLife <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Destroy(collision.gameObject);
    }
}
