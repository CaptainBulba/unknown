using UnityEngine;

[CreateAssetMenu(fileName = "New Photo", menuName = "Album/Photo")]
public class Photo : ScriptableObject
{
    new public string name = "New Photo";
    static public int index = 0;
    public int i;
    public Material icon = null;
    public bool isDefaultPhoto = false;

    Photo()
    {
        index += 1;
        i = index;
    }

    public virtual void Use()
    {
        Debug.Log($"using {name}");
    }
}
