using System.Reflection;
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

    [SerializeField] Effects sideEffect = Effects.None;
    [SerializeField] BgSounds music = BgSounds.None;

    private bool effectUsed = false;
    #endregion

    #region Methods
    public virtual void OnInteract()
    {
        Debug.Log("INTERACTED: " + gameObject.name);
    }

    public void UseEffect()
    {
        if(sideEffect != Effects.None && !effectUsed)
        {
            FindObjectOfType<PlayerState>().SetEffect(sideEffect);
            effectUsed = true;
        }
    }

    public void ChangeMusic()
    {
        MusicManager musicManager = MusicManager.Instance;
        musicManager.GetBackgroundAudio().clip = musicManager.confusionAnxietyBackground;
        musicManager.GetBackgroundAudio().Play();
    }
    #endregion
}