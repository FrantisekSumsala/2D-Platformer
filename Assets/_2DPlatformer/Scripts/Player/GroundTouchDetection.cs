using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTouchDetection : MonoBehaviour
{
    [SerializeField]
    private LayerMask groundLayers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        //collision.gameObject.layer.
    }
}
