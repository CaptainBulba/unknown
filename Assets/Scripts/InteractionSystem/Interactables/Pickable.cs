
public class Pickable : AbstractInteractable
{
    Album album;
    GameManager gameManager;

    public override void OnInteract()
    {
        if (InteractableItem != null)
        {
            album.Add(InteractableItem);
        } else if (InteractableNote != null)
        {
            gameManager.setScrollNote(InteractableNote.note);
        }
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        album = Album.instance;
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
