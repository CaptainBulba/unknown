using System.Collections.Generic;
using UnityEngine;
using System;

public class PhotoAddedToAlbum : EventArgs 
{
    public Photo photo;
    public PhotoAddedToAlbum(Photo it)
    {
        photo = it;
    }
}
public class PhotoRemovedFromAlbum : EventArgs {
    public Photo photo;
    public PhotoRemovedFromAlbum(Photo it)
    {
        photo = it;
    }
}

public class Inventory : MonoBehaviour
{
    public List<Photo> photos = new List<Photo>();
    public int spaceSlots = 3;
    public event EventHandler<PhotoAddedToAlbum> OnPhotoAddedToAlbum = (sender, args) => { };
    public event EventHandler<PhotoRemovedFromAlbum> OnPhotoRemovedFromAlbum = (sender, args) => { };

    Photo _selectedPhoto;

    public Photo selectedPhoto { get { return _selectedPhoto; } set { _selectedPhoto = value; } }

    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Inventory has more than one instance");
            return;
        }

        instance = this;
    }
    #endregion

    private void Start()
    {
    }

    public bool Add(Photo photo)
    {
        if (photo.isDefaultPhoto && photos.Count > spaceSlots)
        {
            print("Inventory is full");
            return false;
        }

        photos.Add(photo);
        // Invoke the event only when a class / method is subscribed to it
        OnPhotoAddedToAlbum?.Invoke(this, new PhotoAddedToAlbum(photo));

        return true;
    }

    public bool Remove(Photo photo)
    {
        photos.Remove(photo);
        // Invoke the event only when a class / method is subscribed to it
        OnPhotoRemovedFromAlbum?.Invoke(this, new PhotoRemovedFromAlbum(photo));
        return true;
    }
}
