using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayDrivingState : PlayBaseState
{
    private IEnumerator coroutine;
    bool isdelivering = false;

    public override void OnEnter(PlayStateManager manager)
    {
        Debug.Log("Driving state");
        DeliverySystem.OnAcceptDelivery+=OnNewDelivery;
    }
    public override void OnUpdate(PlayStateManager manager)
    {
        if(!isdelivering)
            RequestDelivery();
    }
    public override void OnExit(PlayStateManager manager)
    {

    }

    void RequestDelivery(){
        DeliverySystem.Instance.RequestNewDelivery();

    }

    void OnNewDelivery(DeliveryData data)
    {
        isdelivering=true;
        Competitor competitor = new GameObject("Comeptitor",typeof(Competitor)).GetComponent<Competitor>();
        competitor.StartChase(data.pickupLocation,data.deliveryLocation);
    }
}