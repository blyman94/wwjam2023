using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private GameEvent _playerInteractEvent;
    [SerializeField] private GameEvent _playerClickEvent;
    bool playerHasClicked = false;
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

    public void OnClickInput(InputAction.CallbackContext context)
    {
        if (!playerHasClicked)
        {
            playerHasClicked = true;
            if (context.started)
            {
                _playerClickEvent.Raise();
            }
        }
    }
}
