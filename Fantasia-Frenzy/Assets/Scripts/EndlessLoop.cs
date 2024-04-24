using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessLoop : MonoBehaviour
{
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;

    private Transform playerPos;

    private Vector2 newPos;

    private bool isActivated = false;

    private void FixedUpdate()
    {
        if (isActivated && playerPos != null)
        {
            playerPos.position = newPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerPos = collision.GetComponent<Transform>();
            isActivated = true;
            if (this.CompareTag("TriggerStart"))
            {
                newPos = new Vector2(endPoint.position.x, playerPos.position.y);
            }
            if (this.CompareTag("TriggerEnd"))
            {
                newPos = new Vector2(startPoint.position.x, playerPos.position.y);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isActivated = false;
    }
}
