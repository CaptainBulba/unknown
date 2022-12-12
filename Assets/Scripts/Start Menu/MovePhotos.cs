using System.Collections.Generic;
using UnityEngine;

public class MovePhotos : MonoBehaviour
{
    private Dictionary<GameObject, Vector3> photos = new Dictionary<GameObject, Vector3>();
    
    private string photoTag = "Photo";

    [SerializeField] private float moveMagnifier = 3f;

    void Start()
    {
        foreach (GameObject photo in GameObject.FindGameObjectsWithTag(photoTag))
        {
            photos.Add(photo, photo.transform.position);
        }
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        float xNormalized = 2 * (mousePos.x - 0) / (Screen.width - 0) - 1;
        float yNormalized = 2 * (mousePos.y - 0) / (Screen.height - 0) - 1;

        foreach (KeyValuePair<GameObject, Vector3> photo in photos)
        {
            float newX = photo.Value.x - (xNormalized * moveMagnifier);
            float newY = photo.Value.y - (yNormalized * moveMagnifier);
            photo.Key.gameObject.transform.position = new Vector3(newX, newY, photo.Value.z);

            Debug.Log(photo.Key.gameObject.transform.position);
        }
    }
}
