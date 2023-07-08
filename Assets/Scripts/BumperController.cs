using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    [SerializeField] Collider ball;
    [SerializeField] float multiplier = 5f;

    [SerializeField] MaterialSetter material;
    Rigidbody rb;
    Animator anim;
    void Start()
    {
        rb = ball.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        material.Setup(gameObject);
        material.SetAllRenderersColor();    
        material.SetRendererAtIndex(0, true, .5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == ball)
        {

            anim.SetTrigger("hit");

            Vector3 velocity = rb.velocity;

            velocity *= multiplier;

            rb.velocity = velocity;
        }
    }
}
