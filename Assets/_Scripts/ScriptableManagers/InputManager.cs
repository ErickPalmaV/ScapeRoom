using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    [CreateAssetMenu(fileName = "InputManager", menuName = "Managers/InputManager", order = 1)]
    public  class InputManager : ScriptableObject
    {
        private Controls _controls;
        public event Action<Vector2> OnMove;
        public event Action OnJump;
        public event Action OnDash;
        private void OnEnable()
        {
            _controls = new Controls();
            _controls.Player.Enable();
            _controls.Player.Move.performed += Move;
            _controls.Player.Move.canceled += Move;
            _controls.Player.Jump.performed += Jump;
        }

        private void Move(InputAction.CallbackContext context)
        {
           OnMove?.Invoke(context.ReadValue<Vector2>());
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
        }

        private void Jump(InputAction.CallbackContext context)
        {
            OnJump?.Invoke();
        }

        private void Dash(InputAction.CallbackContext context)
        {
            OnDash?.Invoke();
        }
    }
}
