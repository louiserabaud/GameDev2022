using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuState : MonoBehaviour
{
    void Awake()
    {
        //Subscribe to the Game Manager event
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
        SceneManager.LoadSceneAsync("MainMenu");
    }

    void OnDestroy()
    {
        //Unsubscribe to the Game Manager event
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    void GameManagerOnGameStateChanged(GameState state)
    {
        
    }
}
