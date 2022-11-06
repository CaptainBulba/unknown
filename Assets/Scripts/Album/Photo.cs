using UnityEngine;

[CreateAssetMenu(fileName = "New Photo", menuName = "Album/Photo")]
public class Photo : ScriptableObject
{
    new public string name = "New Photo";
    public Sprite icon = null;
    public bool isDefaultPhoto = false;

    public virtual void Use()
    {
        Debug.Log($"using {name}");
    }
}
