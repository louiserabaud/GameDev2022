using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrafficSystem : MonoBehaviour
{
    
    [SerializeField] List<Waypoint> _waypoints= new List<Waypoint>();
    [SerializeField] List<Waypoint> _carObjects= new List<Waypoint>();

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
      
    public void GatherWaypoints()
    {
     
        foreach(Transform child in transform.Find("Waypoints").transform)
        {
            _waypoints.Add(child.GetComponent<Waypoint>());
        }

        foreach(Transform child in transform.Find("Cars").transform)
        {
            _carObjects.Add(child.GetComponent<Waypoint>());
        }
    }

    public List<Waypoint> GetWaypoints()
    {
        return _waypoints;
    }

    public List<Waypoint> GetCars()
    {
        return _carObjects;
    }

    public Transform GetPlayerPosition()
    {
        return transform.Find("PlayerWaypoint").gameObject.GetComponent<Waypoint>().GetTransform();
    }

}
