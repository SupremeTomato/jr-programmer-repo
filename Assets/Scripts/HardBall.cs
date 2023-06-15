using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *** INHERITANCE ***
public class HardBall : BaseBall
{
    private void Start()
    {
        knockbackForce = 20;
        knockbackSpeed = 1;
    }

    protected float upwardForce = 20.0f;

    // *** POLYMORPHYSM ***
    protected override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody ballRB = gameObject.GetComponent<Rigidbody>();
            Vector3 direction = other.gameObject.transform.position - transform.position;
            ballRB.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);
            ballRB.AddForce(-direction * knockbackSpeed * knockbackForce, ForceMode.Impulse);
        }
    }
}
