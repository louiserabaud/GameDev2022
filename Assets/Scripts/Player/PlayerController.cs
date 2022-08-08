using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController _Instance { get; private set; }

    public int penalties=0;

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

    public void CrossedRedLight(){
        penalties+=1;
    }

}
