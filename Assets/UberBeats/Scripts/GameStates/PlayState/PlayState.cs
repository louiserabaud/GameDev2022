using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayState : BaseState
{
   
    private bool isrequest =false;

    public PlayState( )
    {
        Debug.Log("Enter the play state");
    }

    private void Update()
    {
        Debug.Log("up");
    }

    public override void OnEnter()
    {
        EventManager.StartListening("OnAcceptDelivery", OnAcceptDelivery);
    }
    public override void OnTick()
    {
        
    }
    public override void OnExit()
    {

    }

    private void OnAcceptDelivery()
    {

    }

}