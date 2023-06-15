using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public float speed = 10f;


    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotationSpeed;

    private Vector3 inputDir;

    public float playerHeight = 0.5f;
    public LayerMask whatIsGround;
    bool grounded;
    public float groundDrag = 5;


    void Update()
    {

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight + 0.2f, whatIsGround);

        CameraDir();
        SpeedControl();

        
        if(grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    // *** ABSTRACTION ***
    private void MovePlayer()
    {
        rb.AddForce(inputDir.normalized * speed * 10, ForceMode.Force);
    }


    private void CameraDir()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = direction.normalized;
        inputDir = orientation.forward * vertical + orientation.right * horizontal;

        if (inputDir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if(flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

}
