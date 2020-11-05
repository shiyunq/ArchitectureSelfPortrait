using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    bool disabled;
    public event System.Action OnReachedEndOfLevel;

    void Start()
    {
        if (Clock.height < 1)
        {
            transform.localScale = new Vector3(1f, .8f, 1f);
            controller = GetComponent<CharacterController>();
        }
        //transform.position = new Vector3(Clock.X, transform.position.y, Clock.Z);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = Vector3.zero;
        if (!disabled) move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //if (Input.GetButton("Jump"))
        //{
            //Disable();
        //    transform.localScale = new Vector3(1f, .6f, 1f);
        //    controller = GetComponent<CharacterController>();
        //    controller.stepOffset = 1.0f;
        //}

        //if (Input.GetButtonUp("Jump"))
        //{
        //    transform.localScale = new Vector3(1f, 1.6f, 1f);
        //    controller = GetComponent<CharacterController>();
        //    controller.stepOffset = 1.6f;
            //Enable();
        //}

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void Disable()
    {
        disabled = true;
    }

    private void Enable()
    {
        disabled = false;
    }

    void OnTriggerEnter(Collider hitCollider)
    {
        if (hitCollider.tag == "Finish")
        {
            Disable();
            if (OnReachedEndOfLevel != null)
                OnReachedEndOfLevel();
        }
    }
}
