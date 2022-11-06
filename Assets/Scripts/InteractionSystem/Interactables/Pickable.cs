
public class Pickable : AbstractInteractable
{
    Album album;

    public override void OnInteract()
    {
        album.Add(InteractableItem);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        album = Album.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
