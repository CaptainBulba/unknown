using System.Collections;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private PlayerState playerState;

    [SerializeField] private float mouseSensitivity = 100f;
  
    private Transform playerObject;

    private float xRotation = 0f;

    private float mouseX;
    private float mouseY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerObject = gameObject.transform.root;
        playerState = playerObject.GetComponent<PlayerState>();
    }

    private void Update()
    {
        CameraAxis();

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerObject.Rotate(Vector3.up * mouseX);
    }

    public void CameraAxis()
    {
        if (playerState.GetCurrentState() == PlayerStates.CameraInverted)
        {
            mouseX = -Input.GetAxis("Mouse X") * mouseSensitivity;
            mouseY = -Input.GetAxis("Mouse Y") * mouseSensitivity;
        }
        else
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        }
    }
}
