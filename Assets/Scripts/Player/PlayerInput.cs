using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private GameInput _gameInput;

    private void Awake()
    {
        if (_gameInput == null)
        {
            _gameInput = new GameInput();
            _gameInput.Enable();
        }
    }

    private void OnEnable()
    {
        _gameInput.Gameplay.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        _gameInput.Gameplay.Jump.performed -= OnJump;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
       
    }
}
