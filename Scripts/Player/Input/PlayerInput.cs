using System;
using UnityEngine;
using UnityEngine.InputSystem;

 public enum InputContext { Gameplay, UI }

public class PlayerInput : MonoBehaviour
{
    private InputActions _inputActions;
    public InputContext _ctxUsage = InputContext.Gameplay;
    public event Action<Vector2> On_WASD_Performed;
    public event Action<Vector2> On_MouseDelta_Performed;
    public event Action On_ESC_Pressed;
    public event Action On_I_Pressed;
    public event Action On_O_Pressed;
    public event Action On_K_Pressed;
    public event Action On_L_Pressed;
    public event Action On_TAB_Pressed;
    public event Action On_TAB_Released;
    public event Action On_F_Pressed;
    public event Action<float>  On_Q_Pressed_Gameplay;
    public event Action<float>  On_E_Pressed_Gameplay;
    public event Action On_Q_Pressed_UI;
    public event Action On_E_Pressed_UI;

    void Awake()
    {
        _inputActions = new InputActions();
    }

    void OnEnable()
    {
        _inputActions.Enable();
        SubscribeToInputActions();
    }

    void OnDisable()
    {
        _inputActions.Disable();
        UnsubscribeToInputActions();
    }

    private void HandleWASDPerformed(InputAction.CallbackContext ctx)
    {
       On_WASD_Performed?.Invoke(ctx.ReadValue<Vector2>());
    }

    private void HandleMouseDeltaPerformed(InputAction.CallbackContext ctx)
    {
        On_MouseDelta_Performed?.Invoke(ctx.ReadValue<Vector2>());
    }

    private void HandleESCButtonPerformed(InputAction.CallbackContext ctx) => On_ESC_Pressed?.Invoke();
    private void HandleIButtonPerformed(InputAction.CallbackContext ctx) => On_I_Pressed?.Invoke();
    private void HandleOButtonPerformed(InputAction.CallbackContext ctx) => On_O_Pressed?.Invoke();
    private void HandleKButtonPerformed(InputAction.CallbackContext ctx) => On_K_Pressed?.Invoke();
    private void HandleLButtonPerformed(InputAction.CallbackContext ctx) => On_L_Pressed?.Invoke();
    private void HandleTABButtonPerformed(InputAction.CallbackContext ctx) => On_TAB_Pressed?.Invoke();
    private void HandleTabButtonReleased(InputAction.CallbackContext ctx) => On_TAB_Released?.Invoke();
    private void HandleFButtonPerformed(InputAction.CallbackContext ctx) => On_F_Pressed?.Invoke();
    private void HandleQButtonPerformedGameplay(InputAction.CallbackContext ctx) => On_Q_Pressed_Gameplay?.Invoke(ctx.ReadValue<float>());
    private void HandleEButtonPerformedGameplay(InputAction.CallbackContext ctx) => On_E_Pressed_Gameplay?.Invoke(ctx.ReadValue<float>());
    private void HandleQButtonPerformedUI(InputAction.CallbackContext ctx) => On_Q_Pressed_UI?.Invoke();
    private void HandleEButtonPerformedUI(InputAction.CallbackContext ctx) => On_E_Pressed_UI?.Invoke();
    
    public void DisableGameplayInput(bool value)
    {
        if (value)
        {
            _inputActions.Gameplay.Disable();
        }
        else
        {
            _inputActions.Gameplay.Enable();
        }
    }
    private void SubscribeToInputActions()
    {
        // Gameplay related input
        _inputActions.Gameplay.WASD.performed += HandleWASDPerformed;
        _inputActions.Gameplay.WASD.canceled += HandleWASDPerformed;
        _inputActions.Gameplay.F.performed += HandleFButtonPerformed;
        _inputActions.Gameplay.MouseDelta.performed += HandleMouseDeltaPerformed;
        _inputActions.Gameplay.MouseDelta.canceled += HandleMouseDeltaPerformed;
        _inputActions.Gameplay.Q.performed += HandleQButtonPerformedGameplay;
        _inputActions.Gameplay.E.performed += HandleEButtonPerformedGameplay;


        // UI related input
        _inputActions.UI.ESC.performed += HandleESCButtonPerformed;
        _inputActions.UI.I.performed += HandleIButtonPerformed;
        _inputActions.UI.O.performed += HandleOButtonPerformed;
        _inputActions.UI.K.performed += HandleKButtonPerformed;
        _inputActions.UI.L.performed += HandleLButtonPerformed;
        _inputActions.UI.TAB.performed += HandleTABButtonPerformed;
        _inputActions.UI.TAB.canceled += HandleTabButtonReleased;
        _inputActions.UI.Q.performed += HandleQButtonPerformedUI;
        _inputActions.UI.E.performed += HandleEButtonPerformedUI;
        
    }



    private void UnsubscribeToInputActions()
    {
        // Gameplay related input
        _inputActions.Gameplay.WASD.performed -= HandleWASDPerformed;
        _inputActions.Gameplay.WASD.canceled -= HandleWASDPerformed;
        _inputActions.Gameplay.MouseDelta.performed -= HandleMouseDeltaPerformed;
        _inputActions.Gameplay.MouseDelta.canceled -= HandleMouseDeltaPerformed;
        _inputActions.Gameplay.F.performed -= HandleFButtonPerformed;

        // UI related input
        _inputActions.UI.ESC.performed -= HandleESCButtonPerformed;
        _inputActions.UI.I.performed -= HandleIButtonPerformed;
        _inputActions.UI.O.performed -= HandleOButtonPerformed;
        _inputActions.UI.K.performed -= HandleKButtonPerformed;
        _inputActions.UI.L.performed -= HandleLButtonPerformed;
        _inputActions.UI.TAB.performed -= HandleTABButtonPerformed;
        _inputActions.UI.TAB.canceled -= HandleTabButtonReleased;
    }
}
