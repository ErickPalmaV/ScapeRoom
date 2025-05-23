using System;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] float torqueForce, movementForce;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private Vector3 direction= Vector3.right;
    Rigidbody _rb;
    private Transform _objective;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddTorque(direction * torqueForce, ForceMode.Acceleration);
        _objective = pointB;
    }

    private void FixedUpdate()
    {
        if (_rb.GetAccumulatedTorque().magnitude < torqueForce)
        {
            _rb.AddTorque(direction * torqueForce, ForceMode.Acceleration);
        }
        Vector3 directionMovement = (_objective.position - transform.position).normalized;
        _rb.linearVelocity = directionMovement * movementForce;
        if (Vector3.Distance(transform.position, _objective.position)<=0.1f)
        { 
            if (_objective == pointB)
            {
                _objective = pointA;
            }
            else
            {
                _objective = pointB;
            }
        }
    }
}
 


