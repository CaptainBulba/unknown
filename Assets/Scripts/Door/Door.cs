using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
	private Animator doorAnim;
	private GameObject player;

	private bool isOpen = false;

	private float maxDistance = 3f;

	private enum DoorAnims
    {
		Opening,
		Closing
    }

    private void Start()
    {
		player = LevelManager.Instance.GetPlayerObject();
		doorAnim = GetComponent<Animator>();
    }

    private void OnMouseOver()
	{
		if(Vector3.Distance(player.transform.position, transform.position) < maxDistance && Input.GetMouseButtonDown(0))
			UseDoor();
	}

	private void UseDoor()
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

