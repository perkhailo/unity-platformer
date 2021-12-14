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

    [SerializeField]
    private LayerMask _ground;

    private void Awake()
    {
        if(!Rigidbody2D)
            Rigidbody2D = GetComponent<Rigidbody2D>();
        if (!Collider2D)
            Collider2D = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        Vector2 currentMovementDirectory = Rigidbody2D.velocity;

        HorizontalDirectionMovement = GetDirectionMovement((int)currentMovementDirectory.x);
        VerticalDirectionMovement = GetDirectionMovement((int)currentMovementDirectory.y);

        IsGrounded = Collider2D.IsTouchingLayers(_ground);
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
}
