
public class Pickable : AbstractInteractable
{
    Inventory inventory;

    public override void OnInteract()
    {
        inventory.Add(InteractableItem);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
