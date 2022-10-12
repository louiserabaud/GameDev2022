using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
   public enum Algorithm
    {
        AStar
    };

    public class AlgorithmData
    {

    }

    public static class AlgorithmManager
    {
        public static Node FindShortestPath(Algorithm name,
                                            Waypoint start,
                                            Waypoint end,
                                            List<Waypoint> waypoints)
        {
            List<Node> nodes = Graph.GetNodesFromWaypoints(waypoints);
            Node startNode = Graph.FindNodeFromWaypoint(start,ref nodes);
            Node endNode = Graph.FindNodeFromWaypoint(end,ref nodes);
            switch (name)
            {
                case Algorithm.AStar:
                    Node root = AStar.FindShortestPath(nodes,startNode,endNode);
                    return root;
                default:
                    return startNode;
            }
        }
    } 
}
