using UnityEngine;

public class GameManager : MonoBehaviour
{
    Inventory inventory;

    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Inventory has more tha one instance");
            return;
        }

        instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
    }

    void Update()
    {

    }
}
