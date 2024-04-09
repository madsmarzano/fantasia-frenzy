using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDemon : MonoBehaviour
{
    public Transform target;
    public float attackRange;

    private bool isUp = false;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < attackRange && !isUp)
        {
            PopUp();
        }
        else if (Vector2.Distance(transform.position, target.position) > attackRange && isUp)
        {
            Retract();
        }
    }

    private void PopUp()
    {
        animator.Play("Popup");
        isUp = true;
    }

    private void Retract()
    {
        animator.Play("Retract");
        isUp = false;
    }
}
