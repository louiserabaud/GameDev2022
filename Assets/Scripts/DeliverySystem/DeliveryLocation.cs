using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeliveryLocation : MonoBehaviour
{
    public static Action<string> OnDeliver;

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