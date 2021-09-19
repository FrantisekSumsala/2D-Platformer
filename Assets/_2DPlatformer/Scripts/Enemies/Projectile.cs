using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private Vector2 movementDir;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private SpriteRenderer projectileRenderer;

    [SerializeField]
    private Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementDir * movementSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            Destroy(gameObject);
        }
    }
}
