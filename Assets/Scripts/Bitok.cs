using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitok : MonoBehaviour
{
    [SerializeField] private float _impulsePower = 2;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(_impulsePower, 0, 0, ForceMode.Impulse);
    }
}
