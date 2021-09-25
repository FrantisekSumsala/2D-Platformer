using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelFinish : MonoBehaviour
{
    [SerializeField]
    private Transform finishPoint;

    [SerializeField]
    private Vector2 finishSize;

    [SerializeField]
    private float updateRate = 1f;

    [SerializeField]
    private LayerMask playerLayer;

    private float timer = 0f;

    public event Action OnPlayerFinish;

    private void Update()
    {
        if (timer >= updateRate)
        {
            Debug.Log("Finish Check");

            var hit = Physics2D.BoxCast(finishPoint.position, finishSize, 0f, Vector2.zero, 1f, playerLayer);
            if (hit.transform != null)
            {
                Debug.Log("Finish hit");
                OnPlayerFinish?.Invoke();
            }
        }

        timer += Time.time;
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(finishPoint.position.x, finishPoint.position.y, 0f), new Vector3(finishSize.x, finishSize.y, 0f));
    }
#endif

}
