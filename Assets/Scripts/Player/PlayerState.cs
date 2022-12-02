using System.Collections;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private PlayerStates currentState;

    private Movement movement;
    private CameraShake cameraShake;

    private float effectDuration = 5f;
    private float shakeMagnitude = 1f;

    private void Start()
    {
        cameraShake = GetComponentInChildren<CameraShake>();
        movement = GetComponent<Movement>();
        currentState = PlayerStates.Normal;
    }

    private void NormalState()
    {
        currentState = PlayerStates.Normal;
        movement.SlowMovement(false);
    }


    public IEnumerator SlowMovement()
    {
        currentState = PlayerStates.SlowDown;
        movement.SlowMovement(true);

        yield return new WaitForSeconds(effectDuration);

        NormalState();
    }

    public IEnumerator ShakeCamera()
    {
        currentState = PlayerStates.CameraShaking;

        GameObject cameraObject = FindObjectOfType<CameraShake>().gameObject;

        Vector3 originalPos = cameraObject.transform.localPosition;

        float elapsed = 0f;

        while (elapsed < effectDuration)
        {
            float x = Random.Range(-0.1f, 0.1f) * shakeMagnitude;
            float y = Random.Range(-0.1f, 0.1f) * shakeMagnitude;

            cameraObject.transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        cameraObject.transform.localPosition = originalPos;

        NormalState();
    }

    public IEnumerator MovementInverted()
    {
        currentState = PlayerStates.MovementInverted;

        yield return new WaitForSeconds(effectDuration);

        NormalState();
    }

    public IEnumerator CameraInverted()
    {
        currentState = PlayerStates.CameraInverted;

        yield return new WaitForSeconds(effectDuration);

        NormalState();
    }

    public void Freeze(bool value)
    {
        if (value)
            currentState = PlayerStates.Freeze;
        else
            currentState = PlayerStates.Normal;
    }

    public PlayerStates GetCurrentState()
    {
        return currentState;
    }
}
