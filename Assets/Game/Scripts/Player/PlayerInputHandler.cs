using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput _playerInputAction;
    private InputAction _touchAction;
    private InputAction _posAction;
    private bool _isPressed;

    public static event Action<Vector2> OnTouchInput;


    private void Awake()
    {
        _playerInputAction = new PlayerInput();
    }

    private void Update()
    {
        if (_isPressed)
        {
            OnTouchInput?.Invoke(_posAction.ReadValue<Vector2>());
        }
    }

    private void OnEnable()
    {
        _touchAction = _playerInputAction.Player.Touch;
        _posAction = _playerInputAction.Player.Position;

        _touchAction.started += ctx =>
        {
            _isPressed = true;
            OnTouchInput?.Invoke(_posAction.ReadValue<Vector2>());
        };


        _touchAction.canceled += ctx =>
        {
            _isPressed = false;
            OnTouchInput?.Invoke(Vector2.zero);
        };


        _touchAction.Enable();
        _posAction.Enable();
    }
    private void OnDisable()
    {
        _touchAction.Disable();
        _posAction.Disable();

        OnTouchInput = null;
    }

}

