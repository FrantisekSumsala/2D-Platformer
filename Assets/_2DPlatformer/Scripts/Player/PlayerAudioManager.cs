using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField]
    private OnPlayerDamageTaken playerDamage;

    [SerializeField]
    private SoundConfig jumpSound;

    [SerializeField]
    private SoundConfig hitSound;

    private bool jumped = false;
    private bool damaged = false;

    private void OnEnable()
    {
        playerMovement.OnJump += PlayJumpSound;
        playerDamage.OnPlayerDamaged += PlayDamagedSound;
    }

    private void PlayDamagedSound()
    {
        damaged = true;
    }

    private void OnDisable()
    {
        playerMovement.OnJump -= PlayJumpSound;
        playerDamage.OnPlayerDamaged -= PlayDamagedSound;
    }

    private void Update()
    {
        if (damaged)
        {
            damaged = false;
            PlaySound(hitSound);
            return;
        }

        if (playerMovement.IsInAir)
            if (jumped)
            {
                jumped = false;
                PlaySound(jumpSound);
                return;
            }
    }

    private void PlayJumpSound()
    {
        jumped = true;
    }

    private void PlaySound(SoundConfig sound)
    {
        audioSource.clip = sound.sound;
        audioSource.loop = sound.loop;
        audioSource.volume = sound.volume;
        audioSource.Play();
    }
}
