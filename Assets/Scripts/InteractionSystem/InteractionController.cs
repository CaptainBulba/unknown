using UnityEngine;

public class InteractionController : MonoBehaviour
{

    [SerializeField] public InteractionUIPanel uiPanel;

    [Space, Header("Ray Settings")]
    [SerializeField] private float rayDistance = 2f;
   // [SerializeField] private float raySphereRadius = 0f;
    [SerializeField] private LayerMask interactableLayerMask = 7;

    IInteractable interactableObj;

    private Camera m_cam;
    private bool m_interacting = false;
    private float m_holdTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInteraction();
        InitiateInteraction();
    }

    void CheckForInteraction()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rayDistance, interactableLayerMask))
        {
            interactableObj = hit.collider.GetComponent<IInteractable>();

            if (interactableObj != null)
            {
                uiPanel.SetTooltip(interactableObj.TooltipMessage);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    m_interacting = true;
                    m_holdTimer = 0f;
                } 
                else if (Input.GetKeyUp(KeyCode.E))
                {
                    m_interacting = false;
                    m_holdTimer = 0f;
                    uiPanel.UpdateProgressBar(0f);
                }
            }
        }
        else
        {
            uiPanel.ResetUI();
        }
    }

    void InitiateInteraction()
    {
        if (!m_interacting) return;

        if (m_interacting)
        {
            if (!interactableObj.IsInteractable)
                return;

            if (interactableObj.HoldInteract)
            {
                m_holdTimer += Time.deltaTime;

                float heldPercent = m_holdTimer / interactableObj.HoldDuration;
                uiPanel.UpdateProgressBar(heldPercent);

                if (heldPercent > 1f)
                {
                    interactableObj.OnInteract();
                    m_interacting = false;
                }
            }
            else
            {
                interactableObj.OnInteract();
                m_interacting = false;
            }
        }
    }
}
