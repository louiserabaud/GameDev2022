using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarNavigator : MonoBehaviour
{
    
    private UnityEngine.AI.NavMeshAgent _navMeshAgent;

    CarController _controller;
    public Waypoint destination;
    public Waypoint currentPosition;

    private void Awake() 
    {
        _controller = GetComponent<CarController>();
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Start() 
    {
        
        _navMeshAgent.SetDestination(currentPosition.transform.position);
    }

    void Update()
    {
        if(currentPosition==destination)
        {
            Debug.Log("Reached destination!");
            return;
        }
            
        if(!_navMeshAgent.pathPending && currentPosition.neighbours.Count>=1)
        {
            Debug.Log(currentPosition.transform.position);
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance) 
            {
                if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude == 0f) 
                {
                    currentPosition = currentPosition.neighbours[0];
                    _navMeshAgent.SetDestination(currentPosition.transform.position);
                }
            }
            
        }
       

    }
    
}
