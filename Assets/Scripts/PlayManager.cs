using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    static GameObject _Player;
    void Awake(){
        OnEnter();
    }

    void OnEnter(){
        /// Instantiate the player object fist 
        _Player = (GameObject)  Instantiate(Resources.Load("Player"));
        _Player.name = "Player";
        /// Add the third person camera controller to the main camera 

    }
}
