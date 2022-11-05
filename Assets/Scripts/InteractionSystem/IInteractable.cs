using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    float HoldDuration { get; }
    bool HoldInteract { get; }
    bool IsInteractable { get; }
    string TooltipMessage { get; }

    Photo InteractableItem { get; }
    void OnInteract();
}
