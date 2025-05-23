using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private float torqueForce;
    private Rigidbody rb;

    private void Awake()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddTorque(transform.forward * torqueForce, ForceMode.Acceleration);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
