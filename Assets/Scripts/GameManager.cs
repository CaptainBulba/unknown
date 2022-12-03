using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    Album album;

    [SerializeField] private GameObject albumView;
    [SerializeField] private TextMeshProUGUI photoCount;
    [SerializeField] private GameObject noteScrollCanvas;
    [SerializeField] private TextMeshProUGUI noteScroll;
    [SerializeField] private Dialogue dialogue;

    private GameObject playerObject;
    DialogueManager dialogueManager;

    public List<GameObject> photos = new List<GameObject>();

    #region Singleton
    public static GameManager Instance;

    private bool showAlbumView = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Album has more tha one instance");
            return;
        }

        Instance = this;
    }
    #endregion

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindAllPhotos();
    }

    private void Start()
    {
        dialogueManager = DialogueManager.instance;
        album = Album.instance;
        toggleAlbumView(0);
        album.OnPhotoAddedToAlbum += updatePhotoCount;
        playerObject = FindObjectOfType<Movement>().gameObject;
        Invoke("displayPlayerThought", 3.0f);
    }

    public void SetDialogue(Dialogue d)
    {
        dialogue = d;
    }

    private void displayPlayerThought()
    {
        dialogueManager.StartDialogue(dialogue);
        dialogue = null;
    }

    public void setScrollNote(GameObject note, string noteText)
    {
        noteScrollCanvas.SetActive(true);
        noteScroll.text = noteText;

        if(note.GetComponent<NoteActions>() != null)
        {
            note.GetComponent<NoteActions>().DoAction();
        }
    }

    void updatePhotoCount(object o, PhotoAddedToAlbum itemArg)
    {
        photoCount.text = album.photos.Count.ToString();
    }

    public void toggleAlbumView(int show)
    {
        showAlbumView = show == 1 ? true : false;

        foreach (Transform obj in albumView.transform)
        {
            obj.GetComponent<CanvasRenderer>().SetAlpha(show);
        }
        albumView.GetComponent<CanvasRenderer>().SetAlpha(show);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {

            showAlbumView = !showAlbumView;
            toggleAlbumView(showAlbumView ? 1 : 0);
            playerObject.GetComponent<PlayerState>().Freeze(showAlbumView);

            if (!showAlbumView)
            {
                MusicManager.Instance.SetDefaultBackground();

                if (dialogue != null) displayPlayerThought();

                if (photos.Count == 0)
                {
                    playerObject.GetComponent<PlayerState>().Freeze(true);
                    StartCoroutine(FindObjectOfType<Blackout>().InitiateBlackout());
                }

            }

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            noteScroll.text = "";
            noteScrollCanvas.SetActive(false);

            MusicManager.Instance.SetDefaultBackground();
            if (dialogue != null) displayPlayerThought();
        }
    }

    public GameObject GetPlayerObject()
    {
        return playerObject;
    }

    private void FindAllPhotos()
    {
        string photoTag = "Photo";
        foreach (GameObject photo in GameObject.FindGameObjectsWithTag(photoTag))
        {
            photos.Add(photo);
        }
    }

    public void RemovePhoto(GameObject photo)
    {
        photos.Remove(photo);
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
