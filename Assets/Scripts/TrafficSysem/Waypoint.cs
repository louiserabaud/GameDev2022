using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint parent;
    public List<Waypoint> next;
    public int id;
    
    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
