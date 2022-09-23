using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICarTest : MonoBehaviour
{
    public GameObject waypoints;
    public GameObject start;
    public GameObject destination;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Test Dijkstra");
        Graph graph = new Graph();

        
        var count = waypoints.transform.childCount;
        for(int i=0;i<count;i++)
        {
            var waypoint = waypoints.transform.GetChild(i).gameObject.GetComponent<Waypoint>();
            var neighbours = new List<Vector3>();
            foreach(var neighbour in waypoint.neighbours)
            {
                neighbours.Add(neighbour.transform.position);
            }
            graph.AddCoordinates(waypoint.transform.position,neighbours);
        }
        var end = graph.FindNode(
            waypoints.transform.GetChild(2).gameObject.GetComponent<Waypoint>().transform.position
        );
        var start = graph.FindNode(
            waypoints.transform.GetChild(0).gameObject.GetComponent<Waypoint>().transform.position
        );
        var node = Dijkstra.GetShortestPath(graph, start, end);
        
        BackTrack(node);
    }

    List<Vector3> BackTrack(Node node)
    {
        var path = new List<Vector3>();
        var currentNode = node;
        while(currentNode!=null)
        {
             currentNode = currentNode.previous;
        }
        return path;
    }

    
}
