using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum GameState{
    Menu,
    Play
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    bool m_SceneLoaded;
    public Button m_LoadSceneButton, m_SetActiveButton;


    /// FLAGS
    public bool isGameInitiated;
    public bool isGameOver;

    [SerializeField] Camera  _Camera;


    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }

        if (m_LoadSceneButton != null)
        {
            Button loadButton = m_LoadSceneButton.GetComponent<Button>();
            loadButton.onClick.AddListener(LoadSceneButton);
        }

        if (m_SetActiveButton != null)
        {
            Button buttonTwo = m_SetActiveButton.GetComponent<Button>();
            buttonTwo.onClick.AddListener(SetActiveSceneButton);
        }
    }

    // Load the Scene when this Button is pressed
    void LoadSceneButton()
    {
        if (m_SceneLoaded == false)
        {
           
            SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
            m_SceneLoaded = true;

            _Camera.gameObject.AddComponent<CameraController>();
            _Camera.gameObject.GetComponent<CameraController>().enabled = true;
            _Camera.gameObject.transform.position = GetComponent<CameraController>().target.position;

         
        }
    }

    void SetActiveSceneButton()
    {
        if (m_SceneLoaded == true)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Game"));

            Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);
        }
    }
}


