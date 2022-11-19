using UnityEngine;
using UnityEngine.UI;

public class AlbumView : MonoBehaviour
{
    
    Album instance;

    private void Start()
    {
        instance = Album.instance;
        instance.OnPhotoAddedToAlbum += AddPhotoToAlbumView;
    }

    private void AddPhotoToAlbumView(object o, PhotoAddedToAlbum itemArg)
    {
        Photo photo = itemArg.photo;
        RerenderAlbum(photo);
    }

    private void RerenderAlbum(Photo photo)
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "Frame")
            {
                Image photoFrame = child.GetComponent<Image>();

                if (photoFrame.sprite == null)
                {
                    print($"adding {photo.name}");
                    photoFrame.enabled = true;
                    photoFrame.sprite = photo.icon;
                    break;
                }
            }
        }
    }
}
