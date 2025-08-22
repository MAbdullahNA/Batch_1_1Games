using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLocomotion : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    public InputSystem_Actions _inputActions;

    public Vector2 moveInput = Vector2.zero;


    private void OnEnable()
    {
        _inputActions = new InputSystem_Actions();
        _inputActions.Enable();
        _inputActions.Player.Enable();
        _inputActions.Player.SetCallbacks(this);
    }
    private void OnDisable()
    {
        _inputActions.Disable();
        _inputActions.Player.Disable();
        _inputActions.Player.RemoveCallbacks(this);
    }


    #region Interface
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }


    public void OnNext(InputAction.CallbackContext context)
    {
       // throw new System.NotImplementedException();
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
       // throw new System.NotImplementedException();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }
    #endregion
}
