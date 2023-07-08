using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float maxSpeed;

    Rigidbody rb;
    Vector3 defaultGravity;
    Vector3 rampGravity;
    Vector3 ballStartPosition;

    private void Start()
    {
        defaultGravity = new Vector3(0, -9.81f, -10);
        rampGravity = new Vector3(0, -9.81f, -2.5f);
        rb = GetComponent<Rigidbody>();
        ballStartPosition = transform.position;
    }
    private void Update()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //rb.position = ballStartPosition + Vector3.up;
            rb.MovePosition(ballStartPosition + Vector3.up);
            rb.velocity = Vector3.zero;
        }
    }
    
    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Ramp"))
        {
            Physics.gravity = rampGravity;
        }
        else
        {
            Physics.gravity = defaultGravity;
        }

    }

}
