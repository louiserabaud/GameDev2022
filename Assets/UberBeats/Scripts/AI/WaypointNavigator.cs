using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WaypointNavigator 
{
    public static Node FindPath(Node start, Node end, string algorithm)
    {
        return null;
    }

    public static Node GetNextTarget(Node node)
    {
        if(node.next.Count<1)
            return null;
        else if(node.next.Count>1)
            return node.next[Random.Range(0,node.next.Count)];
        else
            return node.next[0];
    }

    public static bool HasReachedDestination(Vector3 position, Node target, float max_distance)
    {
        if(Vector3.Distance(position,target.position)<=max_distance)
            return true;
        return false;
    }

    public static float GetAcceleration(Vector3 position, Node target, Transform transform)
    {
        float acceleration = 1.0f;
        return acceleration;
    }

    public static float GetSteering(Vector3 position, Node target,Transform transform)
    {
        var next = GetNextTarget(target);
        return GetAngleBetweenPositions(position,target.position,transform);
    }

    public static bool CheckForTurn(Vector3 position, Node target, Transform transform)
    {
        if(target.next.Count>1 || target.next.Count<1)
            return true;
        var angle = GetAngleBetweenPositions(position,target.next[0].position,transform);
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