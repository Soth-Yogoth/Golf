using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    [SerializeField] Transform otherPortal;

    private static bool portalsAreEmpty = true;
    private bool isInitiator = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!portalsAreEmpty) return;

        portalsAreEmpty = false;
        isInitiator = true;

        GameObject target = other.GameObject();
        Rigidbody body = other.GetComponent<Rigidbody>();

        target.transform.position = otherPortal.position;

        Vector3 EnterVelocity = transform.InverseTransformDirection(body.linearVelocity);
        body.linearVelocity = otherPortal.TransformDirection(EnterVelocity);
    }

    private void OnTriggerExit(Collider other)
    {
        if(isInitiator) 
        { 
            isInitiator = false;
        }
        else
        {
            portalsAreEmpty = true;
        }
    }
}
