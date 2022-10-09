
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WaypointNavigator 
{
    public static Waypoint FindPath(Waypoint start, Waypoint end, string algorithm)
    {
        return null;
    }

    public static Waypoint GetNextWaypoint(Waypoint waypoint)
    {
        if(waypoint.next.Count<1)
            return null;
        else if(waypoint.next.Count>1)
            return waypoint.next[Random.Range(0,waypoint.next.Count)];
        else
            return waypoint.next[0];
    }

    public static bool HasReachedDestination(Vector3 position, Waypoint target, float max_distance)
    {
        if(target.Distance(position)<=max_distance)
            return true;
        return false;
    }

    public static float GetAcceleration(Vector3 position, Waypoint target, Transform transform)
    {
        float acceleration = 1.0f;
        return acceleration;
    }

    public static float GetSteering(Vector3 position, Waypoint target,Transform transform)
    {
        var next = GetNextWaypoint(target);
        return GetAngleBetweenPositions(position,target.GetPosition(),transform);
    }

    public static bool CheckForTurn(Vector3 position, Waypoint target, Transform transform)
    {
        if(target.next.Count>1 || target.next.Count<1)
            return true;
        var angle = GetAngleBetweenPositions(position,target.next[0].GetPosition(),transform);
        if(angle>0.3f || angle<-0.3f)
            return true;
        return false;
    }

    private static float GetAngleBetweenPositions(Vector3 src, Vector3 dest, Transform transform)
    {
        Vector3 dirToMovePosition = (dest - src).normalized;
        float turnAmount = Mathf.Clamp(transform.InverseTransformDirection(dirToMovePosition).x, -1, 1);
        return turnAmount;
    }
}