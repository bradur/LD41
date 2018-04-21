// Date   : 21.04.2018 08:18
// Project: LD41
// Author : bradur

using UnityEngine;
using System.Collections;

public class VehicleMovement : MonoBehaviour
{


    //private Rigidbody2D rb2d;
    private Rigidbody rb;
    [SerializeField]
    [Range(0.1f, 300f)]
    private float rotationSpeed = 100;

    [SerializeField]
    [Range(0.4f, 500f)]
    private float maxVelocityMagnitude = 5f;
    private float velocityMagnitudeMax = 0f;

    [SerializeField]
    [Range(0.2f, 500f)]
    private float forwardMoveSpeed = 1f;

    [SerializeField]
    [Range(0.2f, 500f)]
    private float backwardMoveSpeed = 1f;

    [SerializeField]
    [Range(0.05f, 1f)]
    private float brakeSpeed = 1f;

    private float brakeTime = 0f;

    private void Start()
    {
        velocityMagnitudeMax = maxVelocityMagnitude;
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");

        bool carMoves = Mathf.Abs(rb.velocity.magnitude) >= 0.05f;
        float verticalAxis = Input.GetAxis("Vertical");
        if (Mathf.Abs(verticalAxis) > 0.05f && rb.velocity.magnitude < velocityMagnitudeMax)
        {
            float moveSpeed;
            if (verticalAxis > 0f)
            {
                moveSpeed = forwardMoveSpeed - brakeTime;
                if (moveSpeed < 0)
                {
                    moveSpeed = 0;
                }
            }
            else
            {
                moveSpeed = -(backwardMoveSpeed - brakeTime);
                if (moveSpeed > 0)
                {
                    moveSpeed = 0f;
                }
            }

            rb.AddForce(transform.forward * moveSpeed, ForceMode.Acceleration);
        }

        if (KeyManager.main.GetKey(GameAction.Brake))
        {
            brakeTime += Time.fixedDeltaTime;
            Vector3 velocity;
            if (rb.velocity.magnitude > 0f)
            {
                velocity = rb.velocity - transform.forward * brakeSpeed;
                if (velocity.magnitude < 0f)
                {
                    velocity = Vector3.zero;
                }
            }
            else if (rb.velocity.magnitude > 0f)
            {
                velocity = rb.velocity + transform.forward * brakeSpeed;
                if (velocity.magnitude > 0f)
                {
                    velocity = Vector3.zero;
                }
            }
        }
        else
        {
            brakeTime = 0f;
        }

        carMoves = Mathf.Abs(rb.velocity.magnitude) >= 0.05f;
        if (Mathf.Abs(horizontalAxis) > 0.05 && carMoves)
        {
            float rotateSpeed = horizontalAxis > 0 ? rotationSpeed : -rotationSpeed;
            // Rotate around the world y-axis
            rb.AddTorque(transform.up * rotateSpeed, ForceMode.Force);
            //transform.Rotate(Vector3.up * rotateSpeed);
        }



    }

    /*private void FixedUpdate()
    {
        // Multiply speed with the input.
        // var speed can be changed in the inspector
        // without changing any scripts
        float force = Input.GetAxis("Vertical");
        float moveSpeed = force > 0 ? forwardMoveSpeed : -backwardMoveSpeed;
        force = moveSpeed * force;
        // Don’t multiply by Time.deltaTime
        // since forces are already time independent.
        // Apply force along the z axis of the object
        rb.AddForce(transform.forward * force, ForceMode.Acceleration);
        float torque = Input.GetAxis("Horizontal");
        torque = rotationSpeed * torque;
        // Rotate around the world y-axis
        rb.AddTorque(0, torque, 0);
    }*/

}
