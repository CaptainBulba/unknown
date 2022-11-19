using UnityEngine;

public class Door : MonoBehaviour
{
	private Animator doorAnim;
	private bool isOpen = false;

	[SerializeField] private bool isLocked = false; 

	private enum DoorAnims
    {
		Opening,
		Closing
    }

    private void Start()
    {
		doorAnim = GetComponent<Animator>();
    }

	public void UseDoor()
	{
		if (!isLocked)
		{
			DoorAnims anim;

			if (isOpen)
				anim = DoorAnims.Closing;
			else
				anim = DoorAnims.Opening;

			isOpen = !isOpen;
			doorAnim.Play(anim.ToString());
		}
		else
			Debug.Log("door is locked");
	}

	public void UnlockDoor()
    {
		isLocked = false;
    }
}

