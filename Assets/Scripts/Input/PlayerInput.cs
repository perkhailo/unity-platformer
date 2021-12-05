using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class PlayerInput : ScriptableObject, GameInput.IGameplayActions
{
    public event UnityAction jumpEvent = delegate { };
    public event UnityAction<Vector2> movementEvent = delegate { };

    private GameInput _gameInput;

    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new GameInput();
            _gameInput.Gameplay.SetCallbacks(this);
        }

        EnableGameplayInput();
    }

    private void OnDisable()
    {
        DisableGameplayInput();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase.Equals(InputActionPhase.Performed))
            jumpEvent.Invoke();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        movementEvent.Invoke(context.ReadValue<Vector2>());
    }

    public void EnableGameplayInput()
    {
        _gameInput.Gameplay.Enable();
    }

    public void DisableGameplayInput()
    {
        _gameInput.Gameplay.Disable();
    }
}
