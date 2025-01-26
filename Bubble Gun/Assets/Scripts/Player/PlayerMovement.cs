using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public enum PlayerId
{
    PLAYER_1,
    PLAYER_2
}

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _direction = Vector2.zero;
    [SerializeField] private float _speed = 5f;
    private Inputs _inputs;
    [SerializeField] private PlayerId _playerId;
    public PlayerId PlayerId => _playerId;
    [SerializeField] private LayerMask _hitLayer;
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceDuration;

    private void Start()
    {
        SetInputs();   
    }

    private void SetInputs()
    {
        _inputs = new Inputs();
        _inputs.Enable();

        if(_playerId == PlayerId.PLAYER_1)
        {
            SetPlayer1Inputs();
        }
        else
        {
            SetPlayer2Inputs();
        }
    }

    private void SetPlayer1Inputs()
    {
        _inputs.Player1.Move_Horizontal.started += SetHorizontalDirection;
        _inputs.Player1.Move_Vertical.started += SetVerticalDirection;
        _inputs.Player1.Move_Horizontal.canceled += SetHorizontalDirection;
        _inputs.Player1.Move_Vertical.canceled += SetVerticalDirection;
    }

    private void SetPlayer2Inputs()
    {
        _inputs.Player2.Move_Horizontal.started += SetHorizontalDirection;
        _inputs.Player2.Move_Vertical.started += SetVerticalDirection;
        _inputs.Player2.Move_Horizontal.canceled += SetHorizontalDirection;
        _inputs.Player2.Move_Vertical.canceled += SetVerticalDirection;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogWarning("Entrou aqui");
        if ((_hitLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            Debug.LogWarning("Acertou, miseravi");
            if (other is EdgeCollider2D edgeCollider)
            {
                Vector2 hitPoint = edgeCollider.ClosestPoint(transform.position);
                Debug.LogWarning($"Hit the edge at point: {hitPoint}");
                OnHitEdge(edgeCollider, hitPoint);
            }
        }
    }

    private void OnHitEdge(EdgeCollider2D edgeCollider, Vector2 hitPoint)
    {
        // Add your logic for when the player hits the edge
        // You can use the hitPoint for further calculations or visual effects

        // Example: Draw a debug line to visualize the hit point
        Debug.DrawLine(transform.position, hitPoint, Color.red, 1f);

        Vector2 normal = -(hitPoint - (Vector2)transform.position).normalized;
        Debug.LogWarning($"Normal {normal}");
        // Add more logic here as needed

        transform.DOMove(normal * _bounceForce, _bounceDuration).SetEase(Ease.OutBack).SetRelative(true);
    }
}
