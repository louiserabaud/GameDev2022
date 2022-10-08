using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public enum GameState
    {
        Menu = 0 ,
        Play = 1
    }


public class GameManager : MonoBehaviour
{
    private GameStateFactory _gameStateFactory;
    private GameState _currentGameState;

    public static GameManager Instance { get; private set; }

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
        //register to switch state event   
        GameStateEntity.SwitchState += SwitchGameState;
    }

    private void Start(){
        SwitchGameState(GameState.Play);
    }

    private void SwitchGameState(GameState newState){
        GameStateFactory.LoadState(newState);
        _currentGameState = newState;
        if (!IsSceneLoaded()){
            StartCoroutine(LoadNewScene());
        }
    }

    private bool IsSceneLoaded(){
        return (SceneManager.GetActiveScene().buildIndex == (int)_currentGameState);
    }

    IEnumerator LoadNewScene(){
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene((int)_currentGameState, LoadSceneMode.Additive);
        yield return null;
        SceneManager.UnloadSceneAsync(currentSceneIndex);
    }
}
