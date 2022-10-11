using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickupLocation : MonoBehaviour
{
    public static Action OnPickup;
    [SerializeField] private Waypoint _waypoint;

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

    public Waypoint GetClosestWaypoint()
    {
        return _waypoint;
    }
}