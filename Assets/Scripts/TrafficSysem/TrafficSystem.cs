using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrafficSystem : MonoBehaviour
{
    
    private List<Waypoint> waypoints;
    private List<Intersection> intersections;

    public static TrafficSystem Instance { get; private set; }

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
    }

    private void Start()
    {
        waypoints= new List<Waypoint>();
        GatherWaypoints();
    }
      
    private void GatherWaypoints()
    {
        foreach(Transform child in transform.GetChild(0).transform)
        {
            waypoints.Add(
                child.GetComponent<Waypoint>()
            );
        }
    }

    public List<Waypoint> GetWaypoints()
    {
        return Waypoints.Duplicate(waypoints);
    }

}
