using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewBobbing : MonoBehaviour
{
    [SerializeField] PlayerMovement pm;
    [SerializeField] Rigidbody rb;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (pm != null && rb != null)
        {
            animator.SetFloat("Blend", rb.velocity.magnitude / pm.maxSpeed);
        }
    }
}
