using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("No GameManager Found!");
            return _instance;

        }
    }

    private void Awake()
    {
        _instance = this;
    }


    public bool keyAcquired { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        keyAcquired = false;
    }

    // Update is called once per frame
    void Update()
    {
        print(keyAcquired);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    
}
