using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToObject : MonoBehaviour
{
    [SerializeField]
    private GameObject trackedObject;

    [SerializeField]
    private SpriteRenderer objectRenderer;

    [SerializeField]
    private bool flipFacesToRight = false;

    private void Update()
    {
        var pos = transform.position;
        var playerPos = trackedObject.transform.position;

        if (playerPos.x > pos.x)
            objectRenderer.flipX = flipFacesToRight;
        else
            objectRenderer.flipX = !flipFacesToRight;
    }

}
