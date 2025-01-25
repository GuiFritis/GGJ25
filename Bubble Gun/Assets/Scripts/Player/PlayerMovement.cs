using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _direction = Vector2.zero;
    [SerializeField] private float _speed = 5f;
    private Inputs _inputs;

    private void Start()
    {
        SetInputs();   
    }

    private void SetInputs()
    {
        _inputs = new Inputs();
        _inputs.Enable();

        _inputs.Player1.Move_Horizontal.started += SetHorizontalDirection;
        _inputs.Player1.Move_Vertical.started += SetVerticalDirection;
        _inputs.Player1.Move_Horizontal.canceled += SetHorizontalDirection;
        _inputs.Player1.Move_Vertical.canceled += SetVerticalDirection;
    }

    private void SetHorizontalDirection(InputAction.CallbackContext context)
    {
        _direction.x = context.ReadValue<float>();
    }

    private void SetVerticalDirection(InputAction.CallbackContext context)
    {
        _direction.y = context.ReadValue<float>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}
