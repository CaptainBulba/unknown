
public class Pickable : AbstractInteractable
{
    Album album;
    GameManager gameManager;

    public override void OnInteract()
    {
        if (InteractableItem != null)
        {
            album.Add(InteractableItem);
            gameManager.toggleAlbumView(1);
        } else if (InteractableNote != null)
        {
            gameManager.setScrollNote(this.gameObject, InteractableNote.note);
        }
        Destroy(gameObject);
    }

    void Start()
    {
        album = Album.instance;
        gameManager = GameManager.instance;
    }
}
