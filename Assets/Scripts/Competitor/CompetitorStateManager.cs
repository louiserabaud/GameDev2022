using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompetitorStateManager : MonoBehaviour
{
    private BaseState _CurrentState;

    void Start(){
        _CurrentState = new DrivingState();
    }
    

}
