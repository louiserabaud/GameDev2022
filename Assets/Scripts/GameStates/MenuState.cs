using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuState : MonoBehaviour
{
    public static MenuState _Instance { get; private set; }
    
    private void Awake() 
    { 
        if (_Instance != null && _Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            _Instance = this; 
        }
    }


    public void OnClickPlay(){
       
    }
}
