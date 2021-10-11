using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerDamageTaken : MonoBehaviour
{
    [SerializeField]
    private EntityHealth playerHealth;

    [SerializeField]
    private Rigidbody2D playerRb;

    [SerializeField]
    private PlayerAnimationController playerAnimController;

    [SerializeField]
    private PlayerMovement playerMovement;

    [Tooltip("Duration of player protection in seconds")]
    [SerializeField]
    private float protectionLength = 0f;

    [SerializeField]
    private float playerFreezeLength = 0f;

    [Range(0f, 1f)]
    [SerializeField]
    private float verticalKnockback;

    [SerializeField]
    private float knockbackStrength = 0f;

    public event Action OnPlayerDamaged;

    private float lastTimeHit = 0f;

    public void GetHit(Vector3 damageSourcePos, int damageAmount)
    {
        if (Time.time < lastTimeHit + protectionLength)
            return;

        lastTimeHit = Time.time;

        // take damage
        playerHealth.ChangeHealth(-damageAmount);

        // apply knockback
        Vector2 posDif = transform.position - damageSourcePos;
        Vector2 knockbackForce = new Vector2(posDif.normalized.x, verticalKnockback).normalized * knockbackStrength;
        playerRb.velocity = Vector2.zero;
        playerRb.AddForce(knockbackForce, ForceMode2D.Impulse);

        playerAnimController.PlayHitAnim();

        // freeze player
        playerMovement.enabled = false;
        StartCoroutine(UnfreezePlayer());

        OnPlayerDamaged?.Invoke();
    }

    private IEnumerator UnfreezePlayer()
    {
        yield return new WaitForSeconds(playerFreezeLength);
        playerMovement.enabled = true;
        yield return null;
    }
}
