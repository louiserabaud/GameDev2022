//____________________________________
// Tutorial Reference: 
// https://www.youtube.com/watch?v=Vt8aZDPzRjI
//____________________________________

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStateManager : MonoBehaviour
{
    public PlayBaseState currentState;
    public PlayInitState initState = new PlayInitState();
    public PlayAcceptDeliveryState acceptDeliveryState = new PlayAcceptDeliveryState();
    public PlayDrivingState drivingState = new PlayDrivingState();

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

    public void SwitchState(PlayBaseState state)
    {
        currentState = state;
        currentState.OnEnter(this);
    }
}
