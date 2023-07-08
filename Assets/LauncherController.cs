using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    [SerializeField] Collider ball;
    [SerializeField] KeyCode input;
    [SerializeField] float launchForce;
    [SerializeField] ForceMode launchMode;
    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider == ball)
        {
            ReadInput(collision);
        }
    }

    private void ReadInput(Collision collision)
    {
        if (Input.GetKey(input))
        {
            collision.collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * launchForce, launchMode);
        }
    }
}
