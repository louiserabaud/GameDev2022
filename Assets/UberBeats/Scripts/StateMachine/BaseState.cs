using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseState
{

    public BaseState( )
    {
        
    }


    public abstract void OnEnter();
    public abstract void OnTick();
    public abstract void OnExit();

}