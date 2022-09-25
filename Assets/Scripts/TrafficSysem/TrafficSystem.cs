using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSystem : MonoBehaviour
{
    private List<Waypoint> waypoints;
    private List<Intersection> intersections;

    private void Start()
    {
        waypoints = new List<Waypoint>();
        intersections = new List<Intersection>();
    }

    public void AddWaypoint(Waypoint point)
    {
        waypoints.Add(point);
    }

    public void AddIntersection(Intersection intersection)
    {
        intersections.Add(intersection);
    }
    
    
    public List<Waypoint> Duplicate()
    {
        var waypoints = new List<Waypoint>();
        if(transform.childCount==0)
            return null;
        foreach(var child in transform)
        {
           // waypoints.Add(child.gameObject);
        }
        return waypoints;
    }

   /* public static Waypoint Duplicate(Waypoint n)
    {
        // handle the degenerate case of an empty list
        if (n == null) {
            return null;
        }

        // create the head Waypoint, keeping it for later return
        Waypoint first = new Waypoint();
        first.Data = n.Data;

        // the 'temp' pointer points to the current "last" Waypoint in the new list
        Waypoint temp = first;

        n = n.Next;
        while (n != null)
        {
            Waypoint n2 = new Waypoint();
            n2.Data = n.Data;
            // modify the Next pointer of the last Waypoint to point to the new last Waypoint
            temp.Next = n2;
            temp = n2;
            n = n.Next;
        }

        return first;

    }*/

}
