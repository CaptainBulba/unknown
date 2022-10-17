using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim;
    private bool isOpen = false;

    private string openAnim = "Door Open";
    private string closeAnim = "Door Close";

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            UseDoor();
    }

    private void UseDoor()
    {
        if(isOpen)
        {
            anim.Play(closeAnim, 0, 0);
            isOpen = false;
        }
        else
        {
            anim.Play(openAnim, 0, 0);
            isOpen = true;
        }

    }
}
