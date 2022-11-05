using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    private GameObject playerObject;

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

    private void Start()
    {
        playerObject = FindObjectOfType<Movement>().gameObject;   
    }

    public GameObject GetPlayerObject()
    {
        return playerObject;
    }
}
