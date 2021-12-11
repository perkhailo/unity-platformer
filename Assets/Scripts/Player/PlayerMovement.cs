using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _jumpForce = 5f;

    private Rigidbody2D _rigidbody2D;

    public Vector2 movementValue { private get; set; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>() as Rigidbody2D;

        if (!_rigidbody2D.bodyType.Equals(RigidbodyType2D.Dynamic))
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }

    public void Jump()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}
