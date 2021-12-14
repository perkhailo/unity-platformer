using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsBehaviour))]
public class PlayerMovement : MonoBehaviour
{
    public PhysicsBehaviour PhysicsBehaviour { get; set; }
    [SerializeField]
    private float _speed = 1f;
    [SerializeField]
    private float _jumpForce = 1f;

    private Vector2 _moveDirection;

    private void Awake()
    {
        if (!PhysicsBehaviour)
            PhysicsBehaviour = GetComponent<PhysicsBehaviour>();

        if (!PhysicsBehaviour.Rigidbody2D.bodyType.Equals(RigidbodyType2D.Dynamic))
            PhysicsBehaviour.Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }

    private void FixedUpdate()
    {
        if (PhysicsBehaviour.IsGrounded)
            PhysicsBehaviour.Rigidbody2D.velocity = new Vector2(_moveDirection.x * _speed, PhysicsBehaviour.Rigidbody2D.velocity.y);
    }

    public void Jump()
    {
        if (PhysicsBehaviour.IsGrounded)
            PhysicsBehaviour.Rigidbody2D.AddForce(transform.up * (_jumpForce * PhysicsBehaviour.Rigidbody2D.gravityScale), ForceMode2D.Impulse);
    }

    public void Move(Vector2 direction)
    {
        _moveDirection = direction;
    }
}
