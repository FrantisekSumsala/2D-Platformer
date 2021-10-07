using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossEnding : MonoBehaviour
{
    [SerializeField]
    private Animator bossAnimator;

    [SerializeField]
    private TMPro.TMP_Text bossText;

    [SerializeField]
    private LevelManager levelManager;

    [SerializeField]
    private float transitionDuration = 1f;

    [SerializeField]
    private string bossTextContent;

    [SerializeField]
    private string bossAnimName;

    [SerializeField]
    private AudioSource bossAudio;

    [SerializeField]
    private AudioClip bossSound;

    [SerializeField]
    private SpriteRenderer renderer;

    public void KillBoss()
    {
        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    {
        bossText.text = bossTextContent;
        bossAnimator.Play(bossAnimName);
        bossAudio.clip = bossSound;
        bossAudio.Play();
        yield return new WaitForSeconds(transitionDuration);

        bossText.text = "";
        renderer.enabled = false;
        bossAudio.Stop();
        levelManager.FinishLevel();
        yield return null;
    }
}
