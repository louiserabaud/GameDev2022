using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
public static class WaypointNavigator 
{
    

    public static Vector2 GetAccelerationAndSteering(Vector3 currentPosition, Vector3 target,float minDistanceToTarget, Transform carTransform)
    {
        //default values
        float acceleration = 1f;
        float steering = 0f;

        float distanceToTarget = CheckDistanceToPoint(currentPosition,target);

        if(distanceToTarget>minDistanceToTarget)
            steering = GetAngleBetweenPosAndTarget(currentPosition,target,carTransform); 
        
        return new Vector2(acceleration,steering);

    }

    private static float GetAngleBetweenPosAndTarget(Vector3 current, Vector3 target,Transform carTransform)
    {
        Vector3 dirToMovePosition = (target - current).normalized;
        float turnAmount = Mathf.Clamp(carTransform.InverseTransformDirection(dirToMovePosition).x, -1, 1);
        return turnAmount;
    }

    public static float CheckDistanceToPoint(Vector3 position, Vector3 target)
    {
        return Vector3.Distance(position, target);
    }

    
    public static Waypoint FindNextWaypoint(Waypoint currentPosition)
    {
        if(currentPosition.next.Count>1)
            return GetRandomWaypoint(currentPosition);
        if(currentPosition.next.Count==0)
            return currentPosition;
        return currentPosition.next[0];
    }

    private static Waypoint GetRandomWaypoint(Waypoint currentPosition)
    {
        int randomIndex = Random.Range(0,currentPosition.next.Count);
        return currentPosition.next[randomIndex];
    }

    private static bool CheckForTurn(Vector3 target, Vector3 next, Transform carTransform)
    {
        var angle = GetAngleBetweenPosAndTarget(target,next,carTransform);
        if(angle>0.3f || angle<-0.3f)
        {
            return true;
        }
        return false;
    }

}

*/