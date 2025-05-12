using System;
using Handlers;
using UnityEngine;

namespace Cube
{
    public class CubeHandler : MonoBehaviour
    {
        [SerializeField] private InputHandler _inputHandler; 
        [SerializeField] protected CubeUnit CubeUnit;
        
        protected Vector3 TouchPosition;
        
        private void OnEnable()
        {
            _inputHandler.OnPressStarted += OnPressStarted;
            _inputHandler.OnPressCanceled += OnPressCanceled;
        }

        private void OnDisable()
        {
            _inputHandler.OnPressStarted -= OnPressStarted;
            _inputHandler.OnPressCanceled -= OnPressCanceled;
        }

        protected virtual void OnPressStarted()
        {
            _inputHandler.OnPerformedPointer += OnPerformedPointer;
        }

        protected virtual void OnPerformedPointer()
        {
            TouchPosition = _inputHandler.GetTouchPosition(CubeUnit.transform);
        }
        
        protected virtual void OnPressCanceled()
        {
            _inputHandler.OnPerformedPointer -= OnPerformedPointer;
        }
    }
}