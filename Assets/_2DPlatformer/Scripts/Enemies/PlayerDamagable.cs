using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagable : MonoBehaviour
{
    [SerializeField]
    private LayerMask damagableLayers;

    [SerializeField]
    private int damageAmount;

    [Range(0f, 1f)]
    [SerializeField]
    private float verticalKnockback;

    [SerializeField]
    private float knockbackStrength = 0f;

    [SerializeField]
    private bool destroyOnContact = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ignore layers that are not targeted
        if ((damagableLayers.value & 1 << collision.gameObject.layer) == 0)
            return;

        EntityHealth entityHealth = collision.gameObject.GetComponentInChildren<EntityHealth>();
        if (entityHealth == null)
            Debug.LogError($"Damage collision without corresponding entity health!\nCollisions object names: {gameObject.name}, {collision.gameObject.name}");

        entityHealth.ChangeHealth(-damageAmount);

        Vector2 posDif = collision.transform.position - gameObject.transform.position;
        Vector2 knockbackForce = new Vector2(posDif.normalized.x, verticalKnockback).normalized * knockbackStrength;

        collision.attachedRigidbody.velocity = Vector2.zero;
        collision.attachedRigidbody.AddForce(knockbackForce, ForceMode2D.Impulse);

        if (destroyOnContact)
            Destroy(gameObject);
    }

}
