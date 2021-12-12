using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : AbstractPhysicsBehaviour
{
    [SerializeField]
    private float _speed = 1f;
    [SerializeField]
    private float _jumpForce = 1f;

    private Vector2 _moveDirection;

    protected override void Awake()
    {
        base.Awake();

        if (!base._rigidbody2D.bodyType.Equals(RigidbodyType2D.Dynamic))
            base._rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }

    protected override void Update()
    {
        base.Update();

        base._rigidbody2D.velocity = new Vector2(_moveDirection.x * _speed, base._rigidbody2D.velocity.y);
    }

    public void Jump()
    {
        base._rigidbody2D.AddForce(transform.up * (_jumpForce * base._rigidbody2D.gravityScale), ForceMode2D.Impulse);
    }

    public void Move(Vector2 direction)
    {
        _moveDirection = direction;
    }
}
