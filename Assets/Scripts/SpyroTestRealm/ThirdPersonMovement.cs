using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    //game objects
    public CharacterController controller; //player reference
    public Transform cam; //camera control
    public Transform groundcheck; //falling
    public LayerMask groundMask; //falling

    //moving
    public float speed = 6f;

    public float turnSmoothTime;
    private float turnSmoothVelocity;

    //falling
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;

    //jumping
    public float jumpHeight = 3f;

    Vector3 velocity; //falling
    bool isGrounded; //falling

    //debug check if grounded
    public float distToGround;


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0) ;
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        
        //jumping
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Debug.Log("Jumped");
        }
        else
        {
            Debug.Log(isGrounded);
            Debug.Log("No Jumped");
        }

        //falling
        velocity.y = gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    //debug check if grounded
    private void FixedUpdate()
    {
        if(Physics.Raycast(transform.position, Vector3.down, distToGround + 2f))
        {
            Debug.Log("Grounded");
        }
        else
        {
            Debug.Log("Not Grounded");
        }
    }
}
