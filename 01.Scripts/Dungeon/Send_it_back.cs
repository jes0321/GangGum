using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Send_it_back : MonoBehaviour
{
    [SerializeField]
    private Vector2 teleportPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Untagged"))
        {

            collision.transform.position = teleportPos;
        }

    }
}
