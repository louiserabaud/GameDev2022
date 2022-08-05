using UnityEngine;

 

    public class PlayState : GameStateEntity
    {
              
        public static PlayState Instance;
        
        void Awake()
        {
            Instance = this;
        }
        public override void OnEnter(){
        }
 
     
    }
