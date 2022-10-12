using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeliveryLocation : MonoBehaviour
{
    public static Action<string> OnDeliver;
    [SerializeField] private Waypoint _waypointA;
    [SerializeField] private Waypoint _waypointB;

    public void SetTransform(Transform _transform)
    {
        transform.position = _transform.position;
        transform.rotation = _transform.rotation;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public Waypoint[] GetClosestWaypoints()
    {
        Waypoint[] points = {_waypointA,_waypointB};
        return points;
    }
}