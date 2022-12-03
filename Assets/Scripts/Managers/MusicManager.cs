using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource objectAudio;

    public AudioClip door;
    public AudioClip closedDoor;
    public AudioClip shelf;
    public AudioClip drawer;
    public AudioClip window;

    public AudioClip fridge;
    public AudioClip oven;

    public AudioClip footsteps;
    public AudioClip pickUpPaperKind;

    public AudioClip earRinging;

    public AudioClip mainBackground;
    public AudioClip confusionAnxietyBackground;

    public static MusicManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
            Destroy(gameObject);
    }

    public AudioSource GetObjectAudio()
    {
        return objectAudio;
    }

    public AudioSource GetBackgroundAudio()
    {
        return FindObjectOfType<BackgroundMusic>().GetComponent<AudioSource>();
    }

    public void SetDefaultBackground()
    {
        if (GetBackgroundAudio().clip != mainBackground)
        {
            GetBackgroundAudio().clip = mainBackground;
            GetBackgroundAudio().Play();
        }
    }   
}
