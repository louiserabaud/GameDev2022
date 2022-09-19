using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Dijkstra 
{
    public static List<Waypoint> GetShortestPath(Waypoint start, Waypoint end)
    {
        var waypoints = new List<Waypoint>();
        var unvisited = new List<Waypoint>();
        var queue = new PriorityQueue<Waypoint>();

        if (start == null || end == null)
            return null;

        //INITIALISATION
        var currentWaypoint = start;
        while(currentWaypoint._nextWaypoint!=null)
        {
            currentWaypoint.distance = float.MinValue;
            currentWaypoint._previousWaypoint = null;
            
        }
        //set the starting node's distance to zero 
        unvisited[0].distance=0;
        //queue.Enqueue()
        //Find the shortest Path
        while(unvisited.Count>0)
        {

        }

        return waypoints;
    }
}
