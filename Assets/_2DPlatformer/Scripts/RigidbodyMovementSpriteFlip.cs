using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovementSpriteFlip : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private SpriteRenderer sr;

    private void Awake()
    {
        if (rb == null)
            rb = gameObject.GetComponentInParent<Rigidbody2D>();

        if (sr == null)
            sr = gameObject.GetComponentInParent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (rb.velocity.x < -0.001f)
        //    sr.flipX = true;
        //else if (rb.velocity.x > 0.001f)
        //    sr.flipX = false;

        if (Input.GetAxisRaw("Horizontal") < -0.001f)
            sr.flipX = true;
        else if (Input.GetAxisRaw("Horizontal") > 0.001f)
            sr.flipX = false;
    }
}
