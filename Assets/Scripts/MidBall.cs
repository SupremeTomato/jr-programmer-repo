using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *** INHERITANCE ***
public class MidBall : BaseBall
{
    private void Start()
    {
        knockbackForce = 30;
        knockbackSpeed = 1;
    }

    // *** POLYMORPHYSM ***
    protected override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody ballRB = gameObject.GetComponent<Rigidbody>();
            Vector3 direction = other.gameObject.transform.position - transform.position;
            ballRB.AddForce(-direction * knockbackSpeed * knockbackForce, ForceMode.Impulse);
        }
    }
}
