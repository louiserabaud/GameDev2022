using UnityEngine;

public abstract class PlayBaseState 
{
    public abstract void OnEnter(PlayStateManager manager);
    public abstract void OnUpdate(PlayStateManager manager);
    public abstract void OnExit(PlayStateManager manager);
}
