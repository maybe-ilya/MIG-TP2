using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MIG.Main
{
    public class TrajectoryInputListener : MonoBehaviour
    {
        private Controls _controls;
        private bool _isAiming;

        public event Action OnStartAiming, OnFinishAiming;
        public event Action<Vector3> OnAiming;

        private void OnEnable()
        {
            _controls = new Controls();
            _controls.Player.AimingControl.started += OnAimingStart;
            _controls.Player.AimingControl.canceled += OnAimingFinish;
            _controls.Player.Enable();
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
            _controls.Player.AimingControl.started -= OnAimingStart;
            _controls.Player.AimingControl.canceled -= OnAimingFinish;
            _controls = null;
        }

        private void OnAimingStart(InputAction.CallbackContext obj)
        {
            _isAiming = true;
            OnStartAiming?.Invoke();
        }

        private void OnAimingFinish(InputAction.CallbackContext obj)
        {
            _isAiming = false;
            OnFinishAiming?.Invoke();
        }

        private void Update()
        {
            if (!_isAiming)
            {
                return;
            }

            var camera = Camera.main;
            var cameraPosition = camera.transform.position;
            var screenPosition = _controls.Player.Aiming.ReadValue<Vector2>();
            var worldPosition =
                camera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, cameraPosition.z));
            worldPosition.z *= -1;

            Debug.LogWarning($"Screen = {screenPosition}, World = {worldPosition}");
            Debug.DrawLine(cameraPosition, worldPosition, Color.magenta, 5);

            OnAiming?.Invoke(worldPosition);
        }
    }
}