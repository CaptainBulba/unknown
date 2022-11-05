using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private PlayerState playerState;

    private float speed;
    private float normalSpeed = 4f;
    private float slowSpeed = 2f;

    private float x;
    private float z;

    private Vector3 velocity;

    private float gravity = -9.81f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerState = GetComponent<PlayerState>();
        speed = normalSpeed;
    }

    private void Update()
    {
        PlayerAxis();

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public void SlowMovement(bool option)
    {
        if (option)
            speed = slowSpeed;
        else
            speed = normalSpeed;
    }

    public void PlayerAxis()
    {
        if(playerState.GetCurrentState() == PlayerStates.MovementInverted)
        {
            x = -Input.GetAxis("Horizontal");
            z = -Input.GetAxis("Vertical");
        }
        else
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }
    }
}
