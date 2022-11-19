using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    Album album;

    [SerializeField] private GameObject albumView;
    [SerializeField] private TextMeshProUGUI photoCount;
    [SerializeField] private GameObject noteScrollCanvas;
    [SerializeField] private TextMeshProUGUI noteScroll;

    private GameObject playerObject;

    #region Singleton
    public static GameManager instance;

    private bool showAlbumView = false;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Album has more tha one instance");
            return;
        }

        instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        album = Album.instance;
        toggleAlbumView(0);
        album.OnPhotoAddedToAlbum += updatePhotoCount;
        playerObject = FindObjectOfType<Movement>().gameObject;
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
        foreach (Transform obj in albumView.transform)
        {
            obj.GetComponent<CanvasRenderer>().SetAlpha(show);
        }
        albumView.GetComponent<CanvasRenderer>().SetAlpha(show);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            showAlbumView = !showAlbumView;
            toggleAlbumView(showAlbumView ? 1 : 0);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            noteScroll.text = "";
            noteScrollCanvas.SetActive(false);
        }
    }

    public GameObject GetPlayerObject()
    {
        return playerObject;
    }
}
