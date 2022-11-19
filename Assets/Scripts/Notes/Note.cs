using UnityEngine;

[CreateAssetMenu(fileName = "New Note", menuName = "Notes/Note")]
public class Note : ScriptableObject
{
    new public string name = "New Note";
    [TextArea]
    public string note = "";
}
