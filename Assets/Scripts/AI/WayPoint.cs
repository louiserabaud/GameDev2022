using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint _previousWaypoint;
    public List<Waypoint> neighbours = new List<Waypoint>();
    public List<Waypoint> parents = new List<Waypoint>();

    public float distance;

    public bool isBranch=false;


    [Range (2.5f,5f)]
    public float width = 2.5f;

    [Range (2.5f,5f)]
    public float branchRatio = 1.75f;

    public Vector3 GetPosition()
    {
        Vector3 minBound = transform.position + transform.right * width / 2f;
        Vector3 maxBound = transform.position - transform.right * width / 2f;
        return Vector3.Lerp(minBound,maxBound,Random.Range(0f,1f));
    }

    public float GetDistance(Waypoint other) 
    {
        return Vector3.Distance(GetPosition(),other.GetPosition());
    }
}
