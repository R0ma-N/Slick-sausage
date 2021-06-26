using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sausage : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Collider collider;

    public Vector3 pos { get { return transform.position; }}

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    public void Push(Vector2 force)
    {
        rigidbody.AddForce(force, ForceMode.Impulse);
    }

    public void ActivateRb()
    {
        rigidbody.isKinematic = false;
    }

    public void DisactivateRb()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.isKinematic = false;
    }
}
