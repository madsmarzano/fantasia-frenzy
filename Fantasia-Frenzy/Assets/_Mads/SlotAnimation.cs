using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SlotAnimation : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float activeRange = 3f;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < activeRange)
        {
            animator.Play("Active");
        }
        else if (Vector2.Distance(transform.position, player.position) > activeRange)
        {
            animator.Play("Idle");
        }
    }
}
