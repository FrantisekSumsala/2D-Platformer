using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    [SerializeField]
    private int startHealth;

    private int currentHealth;

    public event Action<int> HealthChanged;
    public event Action EntityDamaged;
    public event Action EntityDied;

    void Awake()
    {
        currentHealth = startHealth;
    }

    public void ChangeHealth(int changeAmount)
    {
        currentHealth += changeAmount;
        HealthChanged?.Invoke(currentHealth);
        if (currentHealth < 1)
            EntityDied?.Invoke();
        else if (changeAmount < 0)
            EntityDamaged?.Invoke();
    }

}
