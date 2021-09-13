using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float horizontalAxisInput = 0f;
    private bool jump = false;
    private bool inAir = false;

    [SerializeField]
    private float movementSpeed = 1f;

    [SerializeField]
    private float jumpForce = 1f;

    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxisInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        } 
    }

    private void FixedUpdate()
    {
        float horizontalForce = horizontalAxisInput * movementSpeed * Time.fixedDeltaTime;
        float verticalForce = 0f;



        //rb.MovePosition(rb.position + new Vector2(horizontalForce, rb.position.y));

        Debug.Log($"Horizontal force: {horizontalForce}");
        Debug.Log($"Vertical force: {verticalForce}");

        rb.AddForce(new Vector2(horizontalForce, 0f), ForceMode2D.Force);

        if (jump && !inAir)
        {
            verticalForce = jumpForce;
            jump = false;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
