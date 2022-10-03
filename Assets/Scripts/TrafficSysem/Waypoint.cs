using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint parent=null;
    public List<Waypoint> next = new List<Waypoint>();
    public int id;
    
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public float Distance(Vector3 other)
    {
        return Vector3.Distance(GetPosition(),other);
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

   
}
