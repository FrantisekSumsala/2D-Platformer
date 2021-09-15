using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGround : MonoBehaviour
{
    [SerializeField]
    private LayerMask groundLayers;

    [SerializeField]
    private float checkDistance = 1f;

    private void Start()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, checkDistance, groundLayers);
        transform.position = hit.point;

        if (hit != null)
        {
            
        }
    }

}
