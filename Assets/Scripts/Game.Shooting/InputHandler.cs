using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MIG.Game.Shooting
{
    [UsedImplicitly]
    public sealed class InputHandler : MonoBehaviour, IInputHandler
    {
        public event Action OnAimingStart;
        public event Action OnAimingFinish;
        public event Action<Vector3> OnAiming;

        private ShootingControls _controls;
        private bool _isAiming;

        private void OnEnable()
        {
            _controls = new ShootingControls();
            _controls.Player.AimingControl.started += OnAimingBegin;
            _controls.Player.AimingControl.canceled += OnAimingEnd;
            _controls.Player.Enable();
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
            _controls.Player.AimingControl.started -= OnAimingBegin;
            _controls.Player.AimingControl.canceled -= OnAimingEnd;
        }

        private void Update()
        {
            if (!_isAiming)
            {
                return;
            }

            ProcessAiming();
        }

        private void OnAimingBegin(InputAction.CallbackContext obj)
        {
            _isAiming = true;
            OnAimingStart?.Invoke();
        }

        private void OnAimingEnd(InputAction.CallbackContext obj)
        {
            _isAiming = false;
            OnAimingFinish?.Invoke();
        }

        private void ProcessAiming()
        {
            var camera = Camera.main;
            var cameraPosition = camera.transform.position;
            var screenPosition = _controls.Player.Aiming.ReadValue<Vector2>();
            var worldPosition =
                camera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, cameraPosition.z));
            worldPosition.z *= -1;
            
            OnAiming?.Invoke(worldPosition);
        }
    }
}