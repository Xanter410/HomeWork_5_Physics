using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superman : MonoBehaviour
{
    [SerializeField] private int _hitPower;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _rigidbody.AddForce(100, 0, 0, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null)
        {
            Vector3 superVector = _rigidbody.position;
            Vector3 collisionVector = collision.rigidbody.position;

            Vector3 hitVector = Vector3.Normalize(superVector - collisionVector) * _hitPower;

            collision.rigidbody.AddForce(-hitVector, ForceMode.Impulse);
        }
    }
}
