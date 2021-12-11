using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1f;
    [SerializeField]
    private float _jumpForce = 1f;

    private Rigidbody2D _rigidbody2D;

    public float MovementValue { get; set; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>() as Rigidbody2D;

        if (!_rigidbody2D.bodyType.Equals(RigidbodyType2D.Dynamic))
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }

    public void Jump()
    {
        
    }

    private void Update()
    {
        _rigidbody2D.velocity = new Vector2(MovementValue * _speed, _rigidbody2D.velocity.y);
    }
}
