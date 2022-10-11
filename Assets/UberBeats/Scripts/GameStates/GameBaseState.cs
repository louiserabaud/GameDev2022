using System;
using UnityEngine;
 
public  abstract class GameBaseState : MonoBehaviour
    {
        public static Action<GameState> SwitchState;
        public abstract void OnEnter(); 
    }
