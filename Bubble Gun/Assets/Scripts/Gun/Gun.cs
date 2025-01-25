using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float maxAngle;
    [SerializeField] private float wobleSpeed;
    [SerializeField] private Transform target;

    void Update()
    {
        Vector3 difference = target.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        float angle = Mathf.Sin(Time.time * wobleSpeed) * maxAngle;
        angle += transform.rotation.z;
        rotationZ += angle;

        transform.rotation = Quaternion.Euler(0f,0f,rotationZ);

    }
}
