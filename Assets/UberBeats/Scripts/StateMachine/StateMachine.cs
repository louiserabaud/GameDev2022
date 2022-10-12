using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StateMachine: MonoBehaviour
{
    private Dictionary<Type,BaseState> _concreteStates;

    public BaseState currentState {get; private set;}

    public void SetStates(Dictionary<Type,BaseState> states)
    {
        _concreteStates = states;
        currentState = _concreteStates.Values.First();
    }

    public void Update()
    {
        Debug.Log("fsm");
        if(currentState==null)
        {
            currentState = _concreteStates.Values.First();
            currentState.OnEnter();
        }
    }

    public void SwitchState(BaseState newState)
    {
        currentState.OnExit();
        currentState = newState;
    }

   

    /*private void OnGUI()
    {
        string content = currentState != null ? currentState.name : "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
    }*/
}