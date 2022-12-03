using UnityEngine;
using System.Collections;

public class Pickable : AbstractInteractable
{
    Album album;
    GameManager gameManager;
    DialogueManager dialogueManager;

    public override void OnInteract()
    {
        if (dialogue.sentences.Length > 0) gameManager.SetDialogue(dialogue);

        if (InteractableItem != null)
        {
            album.Add(InteractableItem);
            gameManager.toggleAlbumView(1);
            gameManager.RemovePhoto(this.gameObject);
        } else if (InteractableNote != null) gameManager.setScrollNote(this.gameObject, InteractableNote.note);

        UseEffect();
        ChangeMusic();

        gameObject.SetActive(false);
    }

    void Start()
    {
        album = Album.instance;
        gameManager = GameManager.Instance;
        dialogueManager = DialogueManager.instance;
    }
}
