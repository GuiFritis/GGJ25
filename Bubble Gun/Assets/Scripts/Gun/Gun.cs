using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

public class Gun : MonoBehaviour 
{
    [SerializeField] private float maxAngle;
    [SerializeField] private float wobleSpeed;
    [SerializeField] private Transform target;
    [SerializeField] private Transform gunPivot;
    private Inputs _inputs;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private PlayerMovement _playerMovement;
    private float tempoDecorrido;
    [SerializeField]private float coolDownTime;

    void Start()
    {
        SetInputs();  
    }

    void Update()
    {
        if(target == null)
        {
            return;
        }

        Vector3 difference = target.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f,rotationZ);
        
        float angle = Mathf.Sin(Time.time * wobleSpeed) * maxAngle;
        angle += transform.rotation.z;
        rotationZ += angle;

        gunPivot.rotation = Quaternion.Euler(0f,0f,rotationZ);
        tempoDecorrido += Time.deltaTime;
    }

    private void shoot(InputAction.CallbackContext context)
    {
        if(tempoDecorrido >= coolDownTime){
            tempoDecorrido = 0;
            Projetil projetil = ProjetilPool.Instance.GetPoolItem();
            projetil.transform.position = FirePoint.position;
            projetil.transform.rotation = gunPivot.transform.rotation;
        }
    }

     private void SetPlayer1Inputs()
    {
        _inputs.Player1.Shoot.started += shoot;
        
    }
      private void SetPlayer2Inputs()
    {
        _inputs.Player2.Shoot.started += shoot;
        
    }
        private void SetInputs()
    {
        _inputs = new Inputs();
        _inputs.Enable();

        if(_playerMovement.PlayerId == PlayerId.PLAYER_1)
        {
            SetPlayer1Inputs();
        }
        else
        {
            SetPlayer2Inputs();
        }
    }


}
