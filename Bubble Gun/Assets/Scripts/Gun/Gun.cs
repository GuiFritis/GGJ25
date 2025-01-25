using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [SerializeField] private float maxAngle;
    [SerializeField] private float wobleSpeed;
    [SerializeField] private Transform target;
    [SerializeField] private Transform gunPivot;
    [SerializeField] private Projetil gob;
    private Inputs _inputs;
    [SerializeField] private PlayerId _playerId;
    



    void Start()
    {
        SetInputs();  
    }

    void Update()
    {
        Vector3 difference = target.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f,rotationZ);
        
        float angle = Mathf.Sin(Time.time * wobleSpeed) * maxAngle;
        angle += transform.rotation.z;
        rotationZ += angle;

        gunPivot.rotation = Quaternion.Euler(0f,0f,rotationZ);

    }



    private void shoot(InputAction.CallbackContext context)
    {


        Projetil newGob = Instantiate(gob,transform.position, transform.rotation);
        newGob.transform.rotation = gunPivot.transform.rotation;
        Debug.Log("Apertou");
    

    }

     private void SetPlayer1Inputs()
    {
        _inputs.Player1.Shoot.started += shoot;
        
    }
      private void SetPlayer2Inputs()
    {
        //_inputs.Player2.Shoot.started += shoot;
        
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


}
