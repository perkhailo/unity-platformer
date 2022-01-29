using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectionType
{
    Positive,
    Negative,
    Static
}

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsBehaviour : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D { get; set; }
    public Collider2D Collider2D { get; set; }
    public DirectionType HorizontalDirectionMovement { get; set; }
    public DirectionType VerticalDirectionMovement { get; set; }
    public bool IsGrounded { get; set; } = false;
    public event Action<Collision2D> GroundCollisionEnterNotify;
    public bool isRunning { get; set; } = false;
    private bool isCalledStartRunnigCallback { get; set; } = false;
    public event Action OnStartRunningNotify;
    private bool isCalledStopRunnigCallback { get; set; } = false;
    public event Action OnStopRunningNotify;

    [SerializeField]
    private LayerMask _ground;

    private void Awake()
    {
        if(!Rigidbody2D)
            Rigidbody2D = GetComponent<Rigidbody2D>();
        if (!Collider2D)
            Collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        Vector2 currentMovementDirectory = Rigidbody2D.velocity;

        HorizontalDirectionMovement = GetDirectionMovement((int)currentMovementDirectory.x);
        VerticalDirectionMovement = GetDirectionMovement((int)currentMovementDirectory.y);

        IsGrounded = Collider2D.IsTouchingLayers(_ground);
    }

    private void FixedUpdate()
    {
        if (!HorizontalDirectionMovement.Equals(DirectionType.Static))
        {
            isRunning = true;
            isCalledStopRunnigCallback = false;
        }

        if (HorizontalDirectionMovement.Equals(DirectionType.Static))
        {
            isRunning = false;
            isCalledStartRunnigCallback = false;
        }
    }

    private void LateUpdate()
    {
        if (isRunning && !isCalledStartRunnigCallback)
        {
            if (OnStartRunningNotify != null)
                OnStartRunningNotify();
            isCalledStartRunnigCallback = true;
        }

        if (!isRunning && !isCalledStopRunnigCallback)
        {
            if (OnStopRunningNotify != null)
                OnStopRunningNotify();
            isCalledStopRunnigCallback = true;
        }
    }

    private DirectionType GetDirectionMovement(int velocity)
    {
        DirectionType directionType;
        switch (velocity)
        {
            case int n when n < 0:
                directionType = DirectionType.Negative;
                break;
            case int n when n > 0:
                directionType = DirectionType.Positive;
                break;
            default:
                directionType = DirectionType.Static;
                break;
        }
        return directionType;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((_ground.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
            if (GroundCollisionEnterNotify != null)
                GroundCollisionEnterNotify(collision);
    }
}
