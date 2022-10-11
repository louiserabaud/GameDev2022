using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Openlist
{
    List<Node> nodes;
    List<float> costs;

}

public static class AStar 
{
    public static Node FindShortestPath(List<Node> nodes, Node start, Node end)
    {
       
        List<Node> openList = new List<Node>();
        List<Node> closedList = new List<Node>();
        foreach(var node in nodes)
        {
            node.cost = float.MaxValue;
            node.parent=null;
        }
        
        nodes[0].cost=0.0f;
        openList.Add(nodes[0]);

        while(openList.Count>0)
        {
            Node currentNode = GetMinValue(openList);
            if(currentNode.Equals(end))
                {
                    return Graph.Backtrack(currentNode);
                }
                

            if (currentNode != null)
            {
                openList.Remove(currentNode);
                closedList.Add(currentNode);
            }

            //generate q childs and 
            foreach(var child in currentNode.next)
            {
                if(IsNodeInList(child,closedList))
                    continue;
                float g = currentNode.cost + Vector3.Distance(child.position,currentNode.position);
                float h = Vector3.Distance(child.position, end.position);
                float f = g + h;

                if(g>child.cost && IsNodeInList(child,openList))
                {
                    continue;
                }
                else
                {
                    child.cost=g;
                    child.parent=currentNode;
                    openList.Add(child);
                }
            }

        }

        return null;
    }

    private static Node GetMinValue(List<Node> openList)
    {
        float minCost=float.MaxValue;
        Node bestNode=null;
        foreach(var node in openList)
        {
            if(node.cost<minCost)
            {
                minCost = node.cost;
                bestNode = node;
            }
        }
        return bestNode;
    }

    private static bool IsNodeInList(Node node, List<Node> list)
    {
        if(FindNodeInList(node,list)==null)
            return false;
        return true;
    }

    private static Node FindNodeInList(Node node, List<Node> list)
    {
        
        foreach(var element in list)
        {
            if(node.Equals(element))
                return element;
        }
        return null;
    }

    
}