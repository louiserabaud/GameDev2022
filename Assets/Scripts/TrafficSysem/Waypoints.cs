using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Waypoints
{
    public static List<Waypoint> waypoints;

    public static List<Waypoint> Duplicate(List<Waypoint> _waypoints)
    {
        List<Waypoint> waypoints = new List<Waypoint>();
        //make a deep copy of all points
        foreach(var waypoint in _waypoints)
        {
            var newPoint = new Waypoint();
            newPoint.SetPosition(waypoint.GetPosition());
            waypoints.Add(newPoint);
        }
        //assign parents
        for(int i=0;i<waypoints.Count;i++)
        {
            Waypoint currentWaypoint= waypoints[i];
            Waypoint parent = GetWaypoint(_waypoints[i].parent.GetPosition());
            currentWaypoint.parent = parent;
            parent.next.Add(currentWaypoint);
        }

        return waypoints;
    }

    public static Waypoint GetWaypoint(Vector3 position)
    {
        int index = FindIndex(position);
        if(index<=0)
            return waypoints[index];
        return null;
    }

    static int FindIndex(Vector3 position)
    {
        int index=0;
        foreach(var waypoint in waypoints)
        {
            if (waypoint.GetPosition()==position)
                return index;
            index++;
        }
        return -1;
    }

}
