using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        if (animator == null)
            animator = gameObject.GetComponentInParent<Animator>();

        if (rb == null)
            rb = gameObject.GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("horizontalSpeed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("verticalSpeed", rb.velocity.y);
        
        // Todo: handle player hit
    }
}
