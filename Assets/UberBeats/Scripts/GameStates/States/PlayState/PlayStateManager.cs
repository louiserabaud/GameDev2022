//____________________________________
// Tutorial Reference: 
// https://www.youtube.com/watch?v=Vt8aZDPzRjI
//____________________________________

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStateManager : MonoBehaviour
{
    PlayBaseState currentState;
    PlayInitState initState = new PlayInitState();
    PlayAcceptDeliveryState acceptDeliveryState = new PlayAcceptDeliveryState();
    PlayDrivingState drivingState = new PlayDrivingState();


    void Start()
    {
        TrafficSystem.Instance.GatherWaypoints();

        currentState = initState;
        currentState.OnEnter(this);
    }

    void Update()
    {
        currentState.OnUpdate(this);
    }

    void SwitchState(PlayBaseState state)
    {
        currentState = state;
        currentState.OnEnter(this);
    }
}
