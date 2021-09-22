using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    [SerializeField]
    private EntityHealth playerHealth;

    [SerializeField]
    private Image[] healthDisplays;

    [SerializeField]
    private Sprite emptyHeart;

    [SerializeField]
    private Sprite filledHeart;

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private float healthDisplayDuration;

    private void OnEnable()
    {
        playerHealth.HealthChanged += ShowHealth;
    }

    private void OnDisable()
    {
        playerHealth.HealthChanged -= ShowHealth;
    }

    private void ShowHealth(int newHealthValue)
    {
        for (int i = 0; i < newHealthValue; i++)
        {
            healthDisplays[i].sprite = filledHeart;
            //Color c = healthDisplays[i].color;
            //c.a = 1;
            //healthDisplays[i].color = c;
        }

        for (int i = newHealthValue; i < healthDisplays.Length; i++)
        {
            healthDisplays[i].sprite = emptyHeart;
            //Color c = healthDisplays[i].color;
            //c.a = 0;
            //healthDisplays[i].color = c;
        }

        canvas.enabled = true;
        StartCoroutine(HideHealthUI());
    }

    private IEnumerator HideHealthUI()
    {
        yield return new WaitForSeconds(healthDisplayDuration);
        canvas.enabled = false;
    }
}
