using UnityEngine;
using System.Collections;

public class Pickable : AbstractInteractable
{
    Album album;
    GameManager gameManager;
    DialogueManager dialogueManager;

    public override void OnInteract()
    {
        if (dialogue.sentences.Length > 0) StartCoroutine(displayThoughts());

        if (InteractableItem != null)
        {
            album.Add(InteractableItem);
            gameManager.toggleAlbumView(1);
            gameManager.RemovePhoto(this.gameObject);
        } else if (InteractableNote != null) gameManager.setScrollNote(this.gameObject, InteractableNote.note);

        UseEffect();
        ChangeMusic();

        Destroy(gameObject);
    }
    public IEnumerator displayThoughts()
    {
        dialogueManager.StartDialogue(dialogue);

        yield return new WaitForSeconds(10f);
    }

    void Start()
    {
        album = Album.instance;
        gameManager = GameManager.Instance;
        dialogueManager = DialogueManager.instance;
    }
}
