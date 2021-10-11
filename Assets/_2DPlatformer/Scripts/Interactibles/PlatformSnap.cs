using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSnap : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.transform.parent = gameObject.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.parent = null;
    }

}
