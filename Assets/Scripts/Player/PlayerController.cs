using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(SpriteRenderer), typeof(FlipFace))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _playerInput;
    private FlipFace _flipFace;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        if (!_playerMovement)
            _playerMovement = GetComponent<PlayerMovement>();
        if (!_flipFace)
            _flipFace = GetComponent<FlipFace>();
    }

    private void OnEnable()
    {
        if (_playerInput)
        {
            _playerInput.jumpEvent += Jump;
            _playerInput.movementEvent += Movement;
        }
    }

    private void OnDisable()
    {
        _playerInput.jumpEvent -= Jump;
    }

    private void Jump()
    {
        _playerMovement.Jump();
    }

    private void Movement(Vector2 value)
    {
        _playerMovement.MovementValue = value.x;
        _flipFace.DirectionInput = value.x;
    }
}
