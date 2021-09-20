using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : InteractibleObject
{
    [SerializeField]
    private int healingAmount = 1;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        var entityHealth = collision.gameObject.GetComponentInChildren<EntityHealth>();
        if (entityHealth.CurrentHealth == entityHealth.MaxHealth)
            return;

        entityHealth.ChangeHealth(healingAmount);

        OnInteractStart.Invoke();

        Destroy(gameObject);
    }

}
