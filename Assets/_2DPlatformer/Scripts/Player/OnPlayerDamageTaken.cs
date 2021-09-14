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
    private float protectionLength;

    [Range(0f, 1f)]
    [SerializeField]
    private float verticalKnockback;

    [SerializeField]
    private float knockbackStrength = 0f;

    private void OnEnable()
    {
        playerHealth.EntityDamaged += ProtectPlayer;
    }

    private void OnDisable()
    {
        playerHealth.EntityDamaged -= ProtectPlayer;
    }

    private void ProtectPlayer()
    {
        playerHealth.enabled = false;
        playerMovement.enabled = false;
        StartCoroutine(DisablePlayerHealth());

        //Vector2 playerVel = playerRb.velocity.normalized;
        //Vector2 knockbackForce = new Vector2(-playerVel.x, verticalKnockback) * knockbackStrength;
        //playerRb.velocity = Vector2.zero;
        //playerRb.AddForce(knockbackForce, ForceMode2D.Impulse);

        playerAnimController.PlayHitAnim();

        
    }

    private IEnumerator DisablePlayerHealth()
    {
        
        yield return new WaitForSeconds(protectionLength);
        playerMovement.enabled = true;
        playerHealth.enabled = true;
        yield return null;
    }
}
