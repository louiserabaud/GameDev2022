using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayState : BaseState
{
   
    private bool isrequest =false;
    private float time;

    public PlayState( )
    {
        Debug.Log("Enter the play state");
        time = Time.time;
        CanvasManager.GetInstance().SwitchCanvas(CanvasType.DrivingScreen);
    }

   
    public override void OnEnter()
    {
        
    }
    public override void OnTick()
    {
        if((Time.time >= time + 3f) && !isrequest)
        {
            DeliverySystem.Instance.RequestNewDelivery();
            isrequest=true;
        }
    }
    public override void OnExit()
    {

    }

    private void OnAcceptDelivery<DeliveryData>(DeliveryData _data)
    {

    }

}