using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectionType
{
    Left,
    Right
}

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1f;
    [SerializeField]
    private float _jumpForce = 1f;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    public float MovementValue { get; set; }
    [SerializeField]
    public DirectionType directionMovement { get; set; }
    [SerializeField]
    DirectionType faceDirectionOrigin = DirectionType.Right;

    private void Awake()
    {
        if (!_rigidbody2D)
            _rigidbody2D = GetComponent<Rigidbody2D>() as Rigidbody2D;

        if (!_rigidbody2D.bodyType.Equals(RigidbodyType2D.Dynamic))
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;

        if (!_spriteRenderer)
            _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        directionMovement = faceDirectionOrigin;
    }

    public void Jump()
    {
        
    }

    private void Update()
    {
        _rigidbody2D.velocity = new Vector2(MovementValue * _speed, _rigidbody2D.velocity.y);

        SetDirectionMovement(MovementValue);
        SetFaceDirection(faceDirectionOrigin);
    }

    private void SetFaceDirection(DirectionType direction)
    {
        if (direction.Equals(DirectionType.Right))
        {
            if (directionMovement.Equals(DirectionType.Right))
                FlipX(false);
            if (directionMovement.Equals(DirectionType.Left))
                FlipX(true);
        }
        if (direction.Equals(DirectionType.Left))
        {
            if (directionMovement.Equals(DirectionType.Right))
                FlipX(true);
            if (directionMovement.Equals(DirectionType.Left))
                FlipX(false);
        }
    }

    private void SetDirectionMovement(float value)
    {
        if (value > 0)
            directionMovement = DirectionType.Right;
        if (value < 0)
            directionMovement = DirectionType.Left;
    }

    private void FlipX(bool value)
    {
        _spriteRenderer.flipX = value;
    }
}
