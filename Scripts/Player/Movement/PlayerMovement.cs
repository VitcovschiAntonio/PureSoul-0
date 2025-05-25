using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private CharacterController _cc;
    private Vector2 _currentMovementValue;
    [SerializeField] private int _walkSpeed = 5;

    void Start()
    {
        SubscribeToEvents();
    }

    void Update()
    {  
        Vector3 moveDirection = new Vector3(_currentMovementValue.x , 0 , _currentMovementValue.y) * _walkSpeed;
        _cc.Move(transform.TransformDirection(moveDirection* Time.deltaTime));
    }

    private void SubscribeToEvents()
    {
        _input.On_WASD_Performed += HandleMovementInputValue;
        _input.On_Q_Pressed_Gameplay += HandleQPressed;

    }

    private void HandleQPressed(float value)
    {
        if (value > 0)
        {
            Debug.Log("Q Pressed");
        }
        else
        {
            Debug.Log("Q Released");
        }

    }

    private void HandleMovementInputValue(Vector2 vector)
    {
        _currentMovementValue = vector;
    }


}
