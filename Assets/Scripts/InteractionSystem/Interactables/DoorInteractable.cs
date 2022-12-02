using System.Reflection;
using UnityEngine;

public class DoorInteractable : AbstractInteractable
{
    private DialogueManager dialogueManager;

    public override void OnInteract()
    {
        if (dialogue.sentences.Length > 0)
            dialogueManager.StartDialogue(dialogue);

        GetComponent<Door>().UseDoor();
        UseEffect();
        ChangeMusic();
    }

    private void Start()
    {
        dialogueManager = DialogueManager.instance;
    }
}
