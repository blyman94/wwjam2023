using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private GameEvent _playerInteractEvent;
    public void OnMovementInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _mover.MoveInput = context.ReadValue<Vector2>();
        }
        else
        {
            _mover.MoveInput = Vector2.zero;
        }
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _playerInteractEvent.Raise();
        }
    }
}
