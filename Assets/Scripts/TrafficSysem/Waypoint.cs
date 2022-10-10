using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint parent=null;
    public List<Waypoint> next = new List<Waypoint>();
    public Vector3 position;
    public int id;
    
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public float Distance(Vector3 other)
    {
        return Vector3.Distance(GetPosition(),other);
    }

    public void SetPosition(Vector3 pos)
    {
       transform.position = pos;
    }

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

    public void Display()
    {
        Debug.Log("Waypoint " + gameObject.name + " at position: "+ transform.position);
        Debug.Log("Parent: \n" + parent);
    }

    public Transform GetTransform()
    {
        return transform;
    }

   
}
