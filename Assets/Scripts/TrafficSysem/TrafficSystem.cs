using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrafficSystem : MonoBehaviour
{
    
    [SerializeField] List<Waypoint> _waypoints=null;
    [SerializeField] List<Waypoint> _carWaypoints=null;

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
        _waypoints= new List<Waypoint>();
        foreach(Transform child in transform.GetChild(0).transform)
        {
            Debug.Log(child.name);
            _waypoints.Add(
                child.GetComponent<Waypoint>()
            );
        }
    }

    public List<Waypoint> GetWaypoints()
    {
        return _waypoints;
    }

}
