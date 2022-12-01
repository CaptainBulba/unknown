using System.Collections;
using UnityEngine;

public class Blackout : MonoBehaviour
{
    private Animator anim;
    private string blackoutAnim = "Blackout";
    private float extraTime = 1f;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public IEnumerator InitiateBlackout()
    {
        anim.Play(blackoutAnim);
        float animationLength = anim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSecondsRealtime(animationLength + extraTime);
        GameManager.Instance.LoadNextScene();
    }
}
