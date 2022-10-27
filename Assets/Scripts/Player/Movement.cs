using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;

    private float speed;
    private float normalSpeed = 10f;
    private float slowSpeed = 2;
    private float jumpHeight = 3f;

    private Vector3 velocity;

    private float gravity = -9.81f;
    private float groundDistance = 0.4f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    private bool isGrounded; 

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        speed = normalSpeed;
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void SlowMovement()
    {
        speed = slowSpeed;
    }


}
