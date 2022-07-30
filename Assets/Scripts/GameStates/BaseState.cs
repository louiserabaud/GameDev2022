using UnityEngine;

public abstract class BaseState
{
    public abstract void EnterState(StateManager _state);
    public abstract void UpdateState(StateManager _state);
    public abstract void OnCollisionEnter(StateManager _state);
}
