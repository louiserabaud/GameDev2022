using UnityEngine;
using UnityEngine.UI;
 

 public class MenuState : GameBaseState
    {
            
        public static MenuState Instance;

        private Button _PlayButton;
        
        void Awake()
        {
            Instance = this;
            //load elements of the scene
           LoadUIElements();
        }

        private void LoadUIElements(){
            ///Store the objects
            _PlayButton = GameObject.Find("PlayButton").GetComponent<Button>();
            ///Add listiners to buttons
            _PlayButton.onClick.AddListener(OnClickPlay);
        }
     
        public override void OnEnter(){
            Debug.Log("Entered the Menu State");
        }

        private void OnClickPlay(){
            SwitchState?.Invoke(GameState.Play);
        }
 
     
    }
