using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     [Header("Movement")]
//     public float moveSpeed;

//     public float groundDrag;

//     [Header("Ground Check")]
//     public float playerHeight;
//     public LayerMask whatIsGround;
//     bool grounded;

//     public Transform orientation;

//     float horizontalInput;
//     float verticalInput;

//     Vector3 moveDirection;

//     Rigidbody rb;

//     // Start is called before the first frame update
//     void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//         rb.freezeRotation = true;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
//         MyInput();
//         if(grounded)
//         {
//             print("g");
//             rb.drag = groundDrag;
//         }
//         else
//         {
//             // rb.drag = 0; 
//         }
//     }

//     private void FixedUpdate()
//     {
//         MovePlayer();
//     }

//     private void MyInput()
//     {
//         horizontalInput = Input.GetAxisRaw("Horizontal");
//         verticalInput = Input.GetAxisRaw("Vertical");
//     }

//     private void MovePlayer()
//     {
//         moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

//         rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
//     }
// }

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (controller.isGrounded == false)
         {
             //Add our gravity Vecotr
             move += Physics.gravity;
         }

        controller.Move(move * speed * Time.deltaTime);
    }
}