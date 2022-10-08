using System;
using UnityEngine;
 
public  abstract class GameStateEntity 
    {
        public static Action<GameState> SwitchState;
        public abstract void OnEnter(); 
    }
