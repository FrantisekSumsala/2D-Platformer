using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollideDamage : MonoBehaviour
{
    [SerializeField]
    private LayerMask damagableLayers;

    [SerializeField]
    private int damageAmount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ignore layers that are not targeted
        if ((damagableLayers.value & 1 << collision.gameObject.layer) == 0)
            return;

        EntityHealth entityHealth = collision.gameObject.GetComponentInChildren<EntityHealth>();
        if (entityHealth == null)
            Debug.LogError($"Damage collision without corresponding entity health!\nCollisions object names: {gameObject.name}, {collision.gameObject.name}");

        entityHealth.ChangeHealth(-damageAmount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ignore layers that are not targeted
        if ((damagableLayers.value & 1 << collision.gameObject.layer) == 0)
            return;

        EntityHealth entityHealth = collision.gameObject.GetComponentInChildren<EntityHealth>();
        if (entityHealth == null)
            Debug.LogError($"Damage collision without corresponding entity health!\nCollisions object names: {gameObject.name}, {collision.gameObject.name}");

        entityHealth.ChangeHealth(-damageAmount);
    }
}
