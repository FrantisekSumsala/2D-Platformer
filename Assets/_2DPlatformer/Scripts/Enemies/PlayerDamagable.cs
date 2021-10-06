using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagable : MonoBehaviour
{
    [SerializeField]
    private LayerMask damagableLayers;

    [SerializeField]
    private int damageAmount;

    [SerializeField]
    private bool destroyOnContact = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ignore layers that are not targeted
        if ((damagableLayers.value & 1 << collision.gameObject.layer) == 0)
            return;

        OnPlayerDamageTaken playerDamage = collision.gameObject.GetComponentInChildren<OnPlayerDamageTaken>();
        playerDamage.GetHit(gameObject.transform.position, damageAmount);

        if (destroyOnContact)
            Destroy(gameObject);
    }

}
