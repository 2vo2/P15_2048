using System;
using UnityEngine;

namespace Handlers
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        
        private ScreenTouch _screenTouch;
        
        public event Action OnPressStarted;
        public event Action OnPerformedPointer;
        public event Action OnPressCanceled;

        private void Awake()
        {
            _screenTouch = new ScreenTouch();
            
            _screenTouch.Player.PressScreen.started += _ => OnPressStarted?.Invoke();
            _screenTouch.Player.PressScreen.canceled += _ => OnPressCanceled?.Invoke();
            _screenTouch.Player.TouchPosition.performed += _ => OnPerformedPointer?.Invoke();
        }

        private void OnEnable()
        {
            _screenTouch.Player.Enable();
        }

        private void OnDisable()
        {
            _screenTouch.Player.Disable();
        }

        public Vector3 GetMousePosition()
        {
            
        }
    }
}