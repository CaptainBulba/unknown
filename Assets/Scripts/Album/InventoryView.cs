using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    Inventory instance;

    private void Start()
    {
        instance = Inventory.instance;
        instance.OnPhotoAddedToAlbum += AddPhotoToAlbumView;
    }

    private void AddPhotoToAlbumView(object o, PhotoAddedToAlbum itemArg)
    {
        Photo photo = itemArg.photo;
        RerenderInventory(photo);
    }

    private void RerenderInventory(Photo photo)
    {
        Debug.Log(photo.i);
        Transform page1 = gameObject.transform.GetChild(0);
        Transform page2 = gameObject.transform.GetChild(1);

        Material[] m = page1.GetChild(photo.i).GetComponent<MeshRenderer>().materials;
        m[1] = photo.icon;
        page1.GetChild(photo.i).GetComponent<MeshRenderer>().materials = m;
        /*foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "Frame")
            {
                Transform pciture = child.GetChild(0);
                Image icon = pciture.GetComponent<Image>();

                if (!icon.IsActive())
                {
                    print($"adding {photo.name}");
                    icon.enabled = true;
                   // icon.sprite = photo.icon;
                    break;
                }
            }
        }*/
    }
}
