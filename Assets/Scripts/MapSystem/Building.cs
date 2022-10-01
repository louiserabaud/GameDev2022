using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public enum Construction{
        buisness,
        house
    };

    public Construction construction;

    public Vector3 getPosition()
    {
        return transform.position;
    }

    public void setCollider()
    {
        gameObject.AddComponent<SphereCollider>();
        var collider = gameObject.GetComponent<SphereCollider>();
        collider.radius = 23;
    }

    public void OnDrawGizmo()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 23);
    }
}
