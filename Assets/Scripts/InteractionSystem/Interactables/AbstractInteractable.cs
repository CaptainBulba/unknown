using UnityEngine;

public class AbstractInteractable : MonoBehaviour, IInteractable
{
    #region Variables    
    [Space, Header("Interactable Settings")]

    [SerializeField] private bool holdInteract = true;
    [SerializeField] private float holdDuration = 1f;

    [Space]
    [SerializeField] private bool isInteractable = true;
    [SerializeField] private string tooltipMessage = "Hold E to Collect";
    [SerializeField] private Photo item;
    [SerializeField] private Note note;

    [SerializeField] protected Dialogue dialogue;

    #endregion

    #region Properties    
    public float HoldDuration => holdDuration;

    public bool HoldInteract => holdInteract;
    public bool IsInteractable => isInteractable;

    public string TooltipMessage => tooltipMessage;

    public Photo InteractableItem => item;
    public Note InteractableNote => note;
    #endregion

    #region Methods
    public virtual void OnInteract()
    {
        Debug.Log("INTERACTED: " + gameObject.name);
    }
    #endregion
}