using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : AbstractInteractable
{
    public override void OnInteract()
    {
        GetComponent<Door>().UseDoor();   
    }
}
