using UnityEngine;

public class UnlockDoor : NoteActions
{
    [SerializeField] private Door door; 
    public override void DoAction()
    {
        door.UnlockDoor();
    }
}
