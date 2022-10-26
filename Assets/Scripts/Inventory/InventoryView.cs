using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    Inventory instance;

    private void Start()
    {
        instance = Inventory.instance;
        instance.OnItemAddedToInventory += AddItemToInventoryView;
    }

    private void AddItemToInventoryView(object o, ItemAddedToInventory itemArg)
    {
        Item item = itemArg.item;
        RerenderInventory(item);
    }

    private void RerenderInventory(Item item)
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "Frame")
            {
                Transform pciture = child.GetChild(0);
                Image icon = pciture.GetComponent<Image>();

                if (!icon.IsActive())
                {
                    print($"adding {item.name}");
                    icon.enabled = true;
                    icon.sprite = item.icon;
                    break;
                }
            }
        }
    }
}
