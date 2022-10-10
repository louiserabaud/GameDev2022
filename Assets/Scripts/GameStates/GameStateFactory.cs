using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateFactory
{
    
    public static void LoadState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Menu:
            //_currentState =  new MenuState();
                return;

            case GameState.Play:
            Resources.Load<GameObject>("Managers/PlayStateManager").GetComponent<PlayStateManager>();
                return;

            default:
                return;
        }
    }
}