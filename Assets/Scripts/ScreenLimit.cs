using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLimit : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {
        GameObject.Destroy(collision.gameObject, 0.2f);
    }
}
