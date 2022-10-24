using UnityEngine;

public class AbstractInteractable : MonoBehaviour, IInteractable
{
    #region Variables    
    [Space, Header("Interactable Settings")]

    [SerializeField] private bool holdInteract = true;
    [SerializeField] private float holdDuration = 1f;

    [Space]
    [SerializeField] private bool isInteractable = true;
    [SerializeField] private string tooltipMessage = "interact";
    [SerializeField] private Item item;
    #endregion

    #region Properties    
    public float HoldDuration => holdDuration;

    public bool HoldInteract => holdInteract;
    public bool IsInteractable => isInteractable;

    public string TooltipMessage => tooltipMessage;

    public Item InteractableItem => item;
    #endregion

    #region Methods
    public virtual void OnInteract()
    {
        Debug.Log("INTERACTED: " + gameObject.name);
    }
    #endregion
}