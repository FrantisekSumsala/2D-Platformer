using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteFlip : MonoBehaviour
{
    [SerializeField]
    private Movement enemyMovement;

    [SerializeField]
    private SpriteRenderer enemyRenderer;

    private void Update()
    {
        Vector3 enemyMovDir = enemyMovement.movementDirection;
        if (enemyMovDir.x < 0)
            enemyRenderer.flipX = false;
        else
            enemyRenderer.flipX = true;
    }


}
