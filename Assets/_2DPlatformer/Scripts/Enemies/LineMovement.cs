using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMovement : Movement
{
    [SerializeField]
    private Transform[] positions;

    [Tooltip("Index of the point the object is meant to travel to first")]
    [SerializeField]
    private int startingPointIndex;

    [SerializeField]
    private bool useRigidbody;

    [SerializeField]
    private Rigidbody2D rb;

    private Vector3[] points;

    private int nextPointIndex;

    protected override void FixedUpdate()
    {
        if (!useRigidbody)
            return;

        Vector3 curPos = gameObject.transform.position;
        Vector3 targetPos = points[nextPointIndex];
        float distanceToTarget = Vector3.Distance(curPos, targetPos);
        float travelDistance = movementSpeed * Time.fixedDeltaTime;

        if (travelDistance < distanceToTarget)
            rb.MovePosition(curPos + movementDirection.normalized * travelDistance);
        else
        {
            rb.MovePosition(targetPos);

            //move to next point
            nextPointIndex++;
            if (nextPointIndex >= points.Length)
                nextPointIndex = 0;

            movementDirection = (points[nextPointIndex] - targetPos).normalized;
        }
    }

    protected override void Start()
    {
        if (positions.Length < 2)
        {
            Debug.LogError($"Line movement with less than two points on game object {gameObject.name}!");
            return;
        }

        if (startingPointIndex < 0 || startingPointIndex > positions.Length - 1)
        {
            Debug.LogError($"Starting point index out of bounds on game object {gameObject.name}!");
            return;
        }

        points = new Vector3[positions.Length];
        for (int i = 0; i < positions.Length; i++)
        {
            points[i] = positions[i].position;
        }

        nextPointIndex = startingPointIndex;
        movementDirection = (points[nextPointIndex] - gameObject.transform.position).normalized;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (useRigidbody)
            return;

        Vector3 curPos = gameObject.transform.position;
        Vector3 targetPos = points[nextPointIndex];
        float distanceToTarget = Vector3.Distance(curPos, targetPos);
        float travelDistance = movementSpeed * Time.deltaTime;

        if (travelDistance < distanceToTarget)
            gameObject.transform.position = curPos + movementDirection.normalized * travelDistance;
        else
        {
            gameObject.transform.position = targetPos;

            //move to next point
            nextPointIndex++;
            if (nextPointIndex >= points.Length)
                nextPointIndex = 0;

            movementDirection = (points[nextPointIndex] - gameObject.transform.position).normalized;
        }

    }

}
