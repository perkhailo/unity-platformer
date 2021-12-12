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
public abstract class AbstractPhysicsBehaviour : MonoBehaviour
{
    protected Rigidbody2D _rigidbody2D;
    protected DirectionType _horizontalDirectionMovement { get; set; }
    protected DirectionType _verticalDirectionMovement { get; set; }
    protected bool isGrounded = false;

    protected virtual void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>() as Rigidbody2D;
    }

    protected virtual void Update()
    {
        Vector2 currentMovementDirectory = _rigidbody2D.velocity;

        _horizontalDirectionMovement = GetDirectionMovement((int)currentMovementDirectory.x);
        _verticalDirectionMovement = GetDirectionMovement((int)currentMovementDirectory.y);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }

    private DirectionType GetDirectionMovement(int value)
    {
        DirectionType directionType;
        switch (value)
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
