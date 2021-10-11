using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    private float horizontalAxisInput = 0f;
    private bool jump = false;
    private bool inAir = true;

    [SerializeField]
    private float movementSpeed = 1f;

    [SerializeField]
    private float jumpForce = 1f;

    [SerializeField]
    private GameObject groundCheckGameObject;

    [SerializeField]
    private float groundCheckLength;

    [SerializeField]
    private float groundCheckHeight;

    public event Action OnJump;

    public bool IsInAir { get { return inAir; } }

    private void Awake()
    {
        if (rb == null)
            rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalAxisInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && !inAir)
            jump = true;
    }

    private void FixedUpdate()
    {
        // horizontal movement
        float horizontalForce = horizontalAxisInput * movementSpeed * Time.fixedDeltaTime;
        rb.AddForce(new Vector2(horizontalForce, 0f), ForceMode2D.Force);

        // flying detection
        if (Physics2D.BoxCast(groundCheckGameObject.transform.position, 
            new Vector2(groundCheckLength, groundCheckHeight), 
            0f, Vector2.zero, 1f, LayerMask.GetMask("Terrain")))
        {
            inAir = false;
        }

        // jumping
        if (jump && !inAir)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jump = false;
            inAir = true;

            OnJump?.Invoke();
        }
        
    }
}
