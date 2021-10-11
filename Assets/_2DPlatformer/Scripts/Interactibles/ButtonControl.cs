using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonControl : MonoBehaviour
{
    [SerializeField]
    private LayerMask interactibleLayers;

    [Tooltip("Indicates whether the button should be pressed from the start.")]
    [SerializeField]
    private bool startPressed = false;

    [SerializeField]
    private Transform scanOrigin;

    [SerializeField]
    private Vector2 scanSize;

    [SerializeField]
    private float updateRate = 1f;

    [SerializeField]
    private UnityEvent OnButtonPressed;

    [SerializeField]
    private UnityEvent OnButtonReleased;

    private bool buttonPressed;

    private float timer = 0f;

    private void Start()
    {
        buttonPressed = startPressed;
    }

    private void Update()
    {
        if (timer >= updateRate)
        {
            timer = 0;

            var hit = Physics2D.BoxCast(scanOrigin.position, scanSize, 0f, Vector2.zero, 1f, interactibleLayers);
            if (hit.collider != null && buttonPressed == false)
            {
                buttonPressed = true;
                OnButtonPressed.Invoke();
            }
            else if (hit.collider == null && buttonPressed == true)
            {
                buttonPressed = false;
                OnButtonReleased.Invoke();
            }
        }

        timer += Time.time;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(scanOrigin.position.x, scanOrigin.position.y, 0f), new Vector3(scanSize.x, scanSize.y, 0f));
    }
#endif

}
