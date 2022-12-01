using System;
using UnityEngine;

public class Door : MonoBehaviour
{
	private Animator doorAnim;
	private bool isOpen = false;

	[SerializeField] private bool isLocked = false;

	private AudioSource audioSource;
	private MusicManager musicManger;

	private enum Tags
    {
		Door,
		Drawer,
		Shelf,
		Window
    }

	private enum DoorAnims
    {
		Opening,
		Closing
    }

    private void Start()
    {
		doorAnim = GetComponent<Animator>();
		musicManger = MusicManager.Instance;
		audioSource = musicManger.GetObjectAudio();
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

			AudioClip clip = null;
			Tags tag;

			if (Enum.TryParse<Tags>(gameObject.tag, out tag))
			{
				switch (tag)
				{
					case Tags.Door:
						clip = musicManger.door;
						break;
					case Tags.Drawer:
						clip = musicManger.drawer;
						break;
					case Tags.Window:
						clip = musicManger.window;
						break;
					case Tags.Shelf:
						clip = musicManger.shelf;
						break;
				}

				audioSource.clip = clip;
				audioSource.Play();
			}  
		}
		else
        {
			audioSource.clip = musicManger.closedDoor;
			audioSource.Play();
			Debug.Log("door is locked");
		}
	}

	public void UnlockDoor()
    {
		isLocked = false;
    }
}

