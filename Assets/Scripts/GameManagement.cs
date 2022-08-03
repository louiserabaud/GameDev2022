using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GameState{
    Menu,
    Play
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    GameState _currentState;
    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public void Start(){
        UpdateGameState(GameState.Menu);
    }

    public void UpdateGameState(GameState newState){
        switch (newState)
        {
            case GameState.Play:
                HandlePlayState();
                break;
            case GameState.Menu:
                HandleMenuState();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState),newState,null);
        }
        OnGameStateChanged?.Invoke(newState);
    }

    private void HandlePlayState(){

    }

    private void HandleMenuState(){

    }
}
