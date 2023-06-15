using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBall : MonoBehaviour
{
    protected int knockbackSpeed = 2;


    protected int knockbackForce = 10;

    // *** ENCAPSULATION ***
    public Rigidbody ballRB
    {
        get { return GetComponent<Rigidbody>(); }

        private set {}

    }
    private void Start()
    {
        
    }

    // *** POLYMORPHYSM ***
    protected virtual void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody ballRB = gameObject.GetComponent<Rigidbody>();
            Vector3 direction = other.gameObject.transform.position - transform.position;
            ballRB.AddForce(-direction * knockbackSpeed * knockbackForce, ForceMode.Impulse);
        }
    }


}
