using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public StateMachine stateMachine => GetComponent<StateMachine>();
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
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitializeStateMachine();
    }
    private void InitializeStateMachine()
    {
        var states = new Dictionary<Type,BaseState>()
        {
            {typeof(PlayState), new PlayState()}
        };

        GetComponent<StateMachine>().SetStates(states);
    }

}