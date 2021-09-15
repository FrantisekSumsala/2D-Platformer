using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField]
    protected float movementSpeed;

    public Vector3 movementDirection { protected set; get; }

    protected abstract void Start();
    protected abstract void Update();
}
