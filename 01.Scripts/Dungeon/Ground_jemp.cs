using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_jemp : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 2f;
    [SerializeField] public float moveDistance = 3f;

    private Vector3 startPosition;
    private bool movingUp = true;

    void Start()
    {
        startPosition = transform.position;
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            if (movingUp)
            {
                transform.position += Vector3.up * moveSpeed * Time.deltaTime;
                if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
                {
                    movingUp = false;
                }
            }
            else
            {
                transform.position += Vector3.down * moveSpeed * Time.deltaTime;
                if (Vector3.Distance(startPosition, transform.position) <= 0.1f)
                {
                    movingUp = true;
                }
            }

            yield return null;
        }
    }
}
