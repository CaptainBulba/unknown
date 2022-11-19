using UnityEngine;

public class Door : MonoBehaviour
{
	private Animator doorAnim;
	private GameObject player;

	private bool isOpen = false;

	private enum DoorAnims
    {
		Opening,
		Closing
    }

    private void Start()
    {
		player = GameManager.instance.GetPlayerObject();
		doorAnim = GetComponent<Animator>();
    }

	public void UseDoor()
	{
		DoorAnims anim;

		if (isOpen)
			anim = DoorAnims.Closing;
		else
			anim = DoorAnims.Opening;

		isOpen = !isOpen;
		doorAnim.Play(anim.ToString());
	}
}

