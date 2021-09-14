using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatformMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject position1;

    [SerializeField]
    private GameObject position2;

    [SerializeField]
    private float transitionDuration;

    private float transitionProgress = 0f;
    private bool firstToSecond = true;


    // Update is called once per frame
    void Update()
    {
        transitionProgress += Time.deltaTime;
        if (transitionProgress >= transitionDuration)
        {
            transitionProgress = transitionDuration;
        }

        Vector2 newPos;
        if (firstToSecond)
            newPos = Vector2.Lerp(position1.transform.position, position2.transform.position, transitionProgress / transitionDuration);
        else
            newPos = Vector2.Lerp(position2.transform.position, position1.transform.position, transitionProgress / transitionDuration);

        transform.position = newPos;

        if (transitionProgress >= transitionDuration)
        {
            transitionProgress = 0f;
            firstToSecond = !firstToSecond;
        }

    }
}
