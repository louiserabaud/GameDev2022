using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public static class Dijkstra 
{
    public static Node GetShortestPath(Graph graph, Node start, Node end)
    {
      
        var unvisited = new List<Node>();
        var queue = new PriorityQueue();

    

        if (graph.nodes.Count<1 || start == null || end == null)
            return null;

        //INITIALISATION
        foreach (var node in graph.nodes)
        {
            node.previous = null;
            if (node.position == start.position)
            {
                node.cost = 0;
                queue.Enqueue(node);
            }
            else
            {
               node.cost = float.MaxValue;
                queue.Enqueue(node);
            }
        }
       
        Debug.Log(queue.Size());
        //set the starting node's distance to zero 
        //unvisited[0].distance=0;
        //queue.Enqueue()
        //Find the shortest Path
        bool found = false;
        while(queue.Size()>0 || !found)
        {
            var node = queue.Dequeue();
            //Debug.Log("****************************");
            //Debug.Log("dequeue: " + node.ToString() + "cost: " + node.cost);
            if(node.position == end.position)
            {
                //Debug.Log("Found path");
                return node;
            }
            foreach(var neighbour in node.neighbours)
            {
                var newCost = node.cost + node.GetDistance(neighbour);
                //Debug.Log("newcost: " + newCost + "     from-> " + neighbour.ToString());
                if (newCost < neighbour.cost)
                {
                    neighbour.cost = newCost;
                    neighbour.previous = node;
                }
            }
            //Debug.Log("****************************");
        }

        return null;
    }
}
