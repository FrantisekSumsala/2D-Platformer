using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private Transform projectileCreationPoint;

    [SerializeField]
    private float delayBetweenShots;

    [SerializeField]
    private float projectileCreationDelay;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private string shootAnimName;

    private float timeCounter = 0;

    private void Update()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= delayBetweenShots)
        {
            timeCounter = 0;
            animator.Play(shootAnimName);
            StartCoroutine(Shoot());
        }

    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(projectileCreationDelay);
        Instantiate(projectilePrefab, projectileCreationPoint.position, Quaternion.identity);
        yield return null;
    }


}
