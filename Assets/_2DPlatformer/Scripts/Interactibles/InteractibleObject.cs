using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public abstract class InteractibleObject : MonoBehaviour
{
    [SerializeField]
    protected LayerMask interactibleLayers;

    [SerializeField]
    protected UnityEvent OnInteractStart;

    [SerializeField]
    protected UnityEvent OnInteractEnd;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if ((interactibleLayers.value & 1 << collision.gameObject.layer) == 0)
            return;
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if ((interactibleLayers.value & 1 << collision.gameObject.layer) == 0)
            return;
    }

}
