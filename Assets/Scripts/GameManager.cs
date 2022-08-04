using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameState{
    Menu,
    Play
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    /// FLAGS
    public bool isGameInitiated;
    public bool isGameOver;


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
    }


}
