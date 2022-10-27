using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private PlayerStates currentState;

    private Movement movement;
    private CameraLook mouseLook;
    private CameraShake cameraShake;

    private float shakeDuration = 5f;
    private float shakeMagnitude = 1f;

    private void Start()
    {
        mouseLook = GetComponentInChildren<CameraLook>();
        cameraShake = GetComponentInChildren<CameraShake>();
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentState = PlayerStates.Normal;
            movement.SlowMovement(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentState = PlayerStates.SlowDown;
            movement.SlowMovement(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentState = PlayerStates.MovementInverted;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentState = PlayerStates.CameraInverted;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentState = PlayerStates.CameraShaking;
            StartCoroutine(cameraShake.Shake(shakeDuration, shakeMagnitude));
        }
    }

    public PlayerStates GetCurrentState()
    {
        return currentState;
    }
}
