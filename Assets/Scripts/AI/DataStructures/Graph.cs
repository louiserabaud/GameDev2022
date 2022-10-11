using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public static  class Graph
{
    public static List<Node> GetNodesFromWaypoints(List<Waypoint>  _waypoints)
    {
        List<Node> _nodes= new List<Node>();
        foreach(Waypoint waypoint in _waypoints)
        {
            Node currentNode = FindNodeFromWaypoint(waypoint,ref _nodes);
            foreach(Waypoint neighbour in waypoint.next)
            {
                currentNode.next.Add(FindNodeFromWaypoint(neighbour,ref _nodes));
            }
        }
        return  _nodes;
    }

    public static Node GetNodeFromWaypoint(Waypoint startWaypoint,List<Waypoint> _waypoints)
    {
        List<Node> _nodes= new List<Node>();
        foreach(Waypoint waypoint in _waypoints)
        {
            Node currentNode = FindNodeFromWaypoint(waypoint,ref _nodes);
            foreach(Waypoint neighbour in waypoint.next)
            {
                currentNode.next.Add(FindNodeFromWaypoint(neighbour,ref _nodes));
            }
        }
        return FindNodeFromWaypoint(startWaypoint,ref _nodes);
    }
    public static  Node FindNodeFromWaypoint(Waypoint waypoint,ref List<Node> _nodes)
    {
        
        int index = GetAtIndex(waypoint.GetPosition(),ref _nodes);
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

    private static int GetAtIndex(Vector3 position, ref List<Node> _nodes)
    {
            int index = 0;
            foreach(Node point in _nodes)
            {
                if(position==point.position)
                    return index;
                index++;
            }
            return -1;
    }

  


    public static Node Backtrack(Node end)
    {
        List<Node> path = new List<Node>();
        Node currentNode = end;
        while(currentNode.parent!=null)
        {
            //get duplicate of current node
            Node clone =  FindNodeInList(currentNode,path);
            Node parent = currentNode.parent.Duplicate();
            if(clone==null)
                {
                    clone = currentNode.Duplicate();
                    path.Add(clone);
                }
            parent.next.Add(clone);
            clone.parent = parent;
        }
        return path[path.Count-1];
    }

    private static   bool IsNodeInList(Node node, List<Node> list)
    {
        if(FindNodeInList(node,list)==null)
            return false;
        return true;
    }

    private static  Node FindNodeInList(Node node, List<Node> list)
    {
        foreach(var element in list)
        {
            if(node.Equals(element))
                return  element;
        }
        return null;
    }


}