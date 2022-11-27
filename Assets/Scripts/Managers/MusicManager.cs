using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource objectAudio;

    public AudioClip door;
    public AudioClip closedDoor;

    public AudioClip shelf;
    public AudioClip drawer;
    public AudioClip window;

    public AudioClip background;

    public AudioClip scaryBackground;

    public AudioClip footsteps;

    public static MusicManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           // DontDestroyOnLoad(gameObject);
        }
      //  else if (Instance != this)
       //     Destroy(gameObject);
    }

    public AudioSource GetObjectAudio()
    {
        return objectAudio;
    }
}
