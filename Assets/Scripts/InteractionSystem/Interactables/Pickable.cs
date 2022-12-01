using UnityEngine;

public class Pickable : AbstractInteractable
{
    Album album;
    GameManager gameManager;
    DialogueManager dialogueManager;

    public override void OnInteract()
    {
        if (dialogue.sentences.Length > 0) displayThoughts();

        if (InteractableItem != null)
        {
            album.Add(InteractableItem);
            gameManager.toggleAlbumView(1);
        } else if (InteractableNote != null) gameManager.setScrollNote(this.gameObject, InteractableNote.note);

        Destroy(gameObject);
    }
    public void displayThoughts()
    {
        dialogueManager.StartDialogue(dialogue);
    }

    void Start()
    {
        album = Album.instance;
        gameManager = GameManager.instance;
        dialogueManager = DialogueManager.instance;
    }
}
