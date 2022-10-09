using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickupLocation : MonoBehaviour
{
    public static Action OnPickup;

    public void SetTransform(Transform _transform)
    {
        transform.position = _transform.position;
        transform.rotation = _transform.rotation;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}