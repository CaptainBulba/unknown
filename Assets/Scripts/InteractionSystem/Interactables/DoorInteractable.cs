using System.Reflection;
using UnityEngine;

public class DoorInteractable : AbstractInteractable
{
    private PlayerState playerState;

    [SerializeField] Effects sideEffect = Effects.None;
    private bool effectUsed = false;

    private enum Effects
    {
        None,
        ShakeCamera, 
        SlowMovement,
        CameraInverted,
        MovementInverted
    }

    private void Start()
    {
        playerState = FindObjectOfType<PlayerState>();
    }

    public override void OnInteract()
    {
        GetComponent<Door>().UseDoor();
        
        if(sideEffect != Effects.None && !effectUsed)
        {
            MethodInfo mi = playerState.GetType().GetMethod(sideEffect.ToString());
            playerState.StartCoroutine(mi.Name, null);
            effectUsed = true;
        }
    }
}
