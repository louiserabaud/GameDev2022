using System;
using UnityEngine;
 
public abstract class GameStateEntity : MonoBehaviour
    {
      

        public static Action<GameState> SwitchState;
      
        public abstract void OnEnter(); 


    }
