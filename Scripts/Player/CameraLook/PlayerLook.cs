using System;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform _cameraHolder;
    [SerializeField] private PlayerInput _input;

    private Vector2 _mouseInputValue;

    private float _xRotation = 0;
    [SerializeField] private float _mouseSensitivity;


    void Start()
    {
        SubscribeToEvents();
        SetCursorState();
    }

    void LateUpdate()
    {
        Look();
    }

    private void SetCursorState()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Look()
    {
        float mouseX = _mouseInputValue.x * _mouseSensitivity;
        float mouseY = _mouseInputValue.y * _mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);
        _xRotation = Mathf.Clamp(_xRotation - mouseY, -80, 80);
        _cameraHolder.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
    }

    private void ChangeLookInputValue(Vector2 vector)
    {
        if(vector != Vector2.zero)
        {
            _mouseInputValue = vector;
        }
        else{
            _mouseInputValue = Vector2.zero;
        }
    }

    private void SubscribeToEvents()
    {
        _input.On_MouseDelta_Performed += ChangeLookInputValue;
    }
    private void UnsubscribeToEvents()
    {
        _input.On_MouseDelta_Performed -= ChangeLookInputValue;

    }
    void OnDisable()
    {
        UnsubscribeToEvents();
    }
}
