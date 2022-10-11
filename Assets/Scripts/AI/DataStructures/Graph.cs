using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Node(Vector3 _position, Transform _transform)
    {
        position=_position;
        transform=_transform;
    }
    public Vector3 position;
    public Transform transform;

    public List<Node> next= new List<Node>();
    public Node parent=null;

}

public class Graph
{
    public List<Node> _nodes= new List<Node>();
    public Graph(List<Waypoint> waypoints)
    {
        CreateFromWaypoints(waypoints);
    }

    private void CreateFromWaypoints(List<Waypoint> _waypoints)
    {
        foreach(Waypoint waypoint in _waypoints)
        {
            Node currentNode = GetNodeFromWaypoint(waypoint);
            foreach(Waypoint neighbour in waypoint.next)
            {
                currentNode.next.Add(GetNodeFromWaypoint(neighbour));
            }
        }
    }
    public  Node GetNodeFromWaypoint(Waypoint waypoint)
    {
        
        int index = GetAtIndex(waypoint.GetPosition());
            Node node = null;
            if(index<0)
            {
                node=waypoint.ToNode();
                _nodes.Add(node);
            }else{
                node=_nodes[index];
            }
            return node;
    }

    private int GetAtIndex(Vector3 position)
    {
            int index = 0;
            foreach(Node point in this._nodes)
            {
                if(position==point.position)
                    return index;
                index++;
            }
            return -1;
    }

    public List<Node> GetNodes()
    {
        return _nodes;
    }
}