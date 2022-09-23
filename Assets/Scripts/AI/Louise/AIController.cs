using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Algorithm
{
    Random,
    Dijkstra,
    PlayerController
}

public class AIController : MonoBehaviour
{
    public GameObject waypoints=null;
    public Waypoint StartLoc=null;
    public Waypoint Destination=null;

    private UnityEngine.AI.NavMeshAgent _navMeshAgent;

    public Algorithm algorithm=Algorithm.Random;

    private List<Vector3> AIPath;
    private Waypoint currentPosition;

    void Awake()
    {
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        AIPath = new List<Vector3>();

        
        
    }

    void Start() 
    {
        _navMeshAgent.destination = StartLoc.transform.position;
        if(algorithm!=Algorithm.Random)
        {
            DijkstraAlg();
        }
        else
        {
            currentPosition = StartLoc;
           
            _navMeshAgent.SetDestination(currentPosition.transform.position);
        }
    }

    void Update()
    {
        if(algorithm == Algorithm.PlayerController)
            return;
        if(!_navMeshAgent.pathPending)
            {
                if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance) 
            {
                if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude == 0f) 
                    {
                        if (AIPath.Count>0)
                        {
                            _navMeshAgent.SetDestination(AIPath[0]);
                            AIPath.RemoveAt(0);
                        }
                        else
                        {
                            if(currentPosition.neighbours.Count>1)
                            {
                                System.Random rnd = new System.Random();
                                currentPosition = currentPosition.neighbours[rnd.Next(currentPosition.neighbours.Count)];
                                //Debug.Log("move to " + currentPosition.transform.position );
                                _navMeshAgent.SetDestination(currentPosition.transform.position);

                            }
                            else{
                                
                                currentPosition = currentPosition.neighbours[0];
                                 //Debug.Log("move to " + currentPosition.transform.position );
                                _navMeshAgent.SetDestination(currentPosition.transform.position);

                            }
                        
                    }
                }
            }
            }
        
    }

    private void FindShortestPath()
    {
        
    }

    private void DijkstraAlg()
    {
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

        var start = graph.FindNode(StartLoc.transform.position);
        var end = graph.FindNode(Destination.transform.position);

        var node = Dijkstra.GetShortestPath(graph, start, end);

        AIPath = BackTrack(node);

    }

      List<Vector3> BackTrack(Node node)
    {
        var path = new List<Vector3>();
        var currentNode = node;
        while(currentNode!=null)
        {
            path.Add(currentNode.position);
             currentNode = currentNode.previous;
             
        }
        foreach(var n in path)
        {
            //Debug.Log(n.ToString());
        }
        path.Reverse();
        return path;
    }
   

    



}
