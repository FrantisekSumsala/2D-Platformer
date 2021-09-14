using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform camera;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private Vector2 horizontalLimits;

    [SerializeField]
    private Vector2 verticalLimits;

    private void LateUpdate()
    {
        Vector2 playerPos = player.position;
        float xPos = playerPos.x;
        if (xPos < horizontalLimits.x)
            xPos = horizontalLimits.x;
        if (xPos > horizontalLimits.y)
            xPos = horizontalLimits.y;

        float yPos = playerPos.y;
        if (yPos < verticalLimits.x)
            yPos = verticalLimits.x;
        if (yPos > verticalLimits.y)
            yPos = verticalLimits.y;

        camera.position = new Vector3(xPos, yPos, camera.position.z);
    }

}
