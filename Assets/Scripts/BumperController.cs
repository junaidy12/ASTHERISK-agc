using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    [SerializeField] Collider ball;
    [SerializeField] float multiplier = 5f;
    [SerializeField] Color color;


    Renderer[] renderers;
    Rigidbody rb;
    Animator anim;
    void Start()
    {
        rb = ball.GetComponent<Rigidbody>();
        renderers = GetComponentsInChildren<Renderer>();
        anim = GetComponent<Animator>();
        foreach(Renderer renderer in renderers)
        {
            renderer.material.color = color;
        }
    }

    void Update()
    {
        renderers[0].material.color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == ball)
        {
            anim.SetTrigger("hit");
            Vector3 velocity = rb.velocity;

            float maxRbVelocity = 15f;

            velocity *= multiplier;
            velocity = Vector3.ClampMagnitude(velocity, maxRbVelocity);

            rb.velocity = velocity;
        }
    }
}
