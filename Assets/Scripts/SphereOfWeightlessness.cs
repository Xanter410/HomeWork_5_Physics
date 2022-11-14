using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereOfWeightlessness : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //other.gameObject.GetComponent<Rigidbody>().useGravity = false;
        other.attachedRigidbody.useGravity = false;
    }

    private void OnTriggerExit(Collider other)
    {
        //other.gameObject.GetComponent<Rigidbody>().useGravity = true;

        other.attachedRigidbody.useGravity = true;
    }
}
