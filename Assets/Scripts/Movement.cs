using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Components
    private Rigidbody rb;

    //Variables
    [SerializeField]private Vector2 movementForce = new Vector2(50f, 1000f);
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.up * movementForce.y * Time.deltaTime); //Add an relative, upward force frame independently
        }
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(1); //Turn left
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-1); //Turn right
        }
    }

    void ApplyRotation(int directionMultiplier)
    {
        rb.freezeRotation = true; //freeze rotation to manually rotate
        transform.Rotate(directionMultiplier * Vector3.forward * movementForce.x * Time.deltaTime);
        rb.freezeRotation = false; //unfreeze rotation
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
    }
}
