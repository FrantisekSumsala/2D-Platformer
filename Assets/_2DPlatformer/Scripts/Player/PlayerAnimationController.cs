using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Rigidbody2D rb;

    private void Awake()
    {
        if (animator == null)
            animator = gameObject.GetComponentInParent<Animator>();

        if (rb == null)
            rb = gameObject.GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        animator.SetFloat("horizontalSpeed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("verticalSpeed", rb.velocity.y);
    }

    public void PlayHitAnim()
    {
        animator.Play("Player_Anim_Hit");
    }
}
