using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint parent=null;
    public List<Waypoint> next = new List<Waypoint>();

    public Node ToNode()
    {
        return new Node(transform.position,transform);
    }

    public void SetTransform(Transform _transform)
    {
       transform.position = _transform.position;
       transform.forward = _transform.forward;
       transform.rotation = _transform.rotation;
    }

    public string GetTag( )
    {
        return gameObject.tag;
    }

    public Transform GetTransform()
    {
        return transform;
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    public void SetPosition(Vector3 position)
    {
        transform.position=position;
    }
}
