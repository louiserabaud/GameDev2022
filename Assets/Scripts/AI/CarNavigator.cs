using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarNavigator : MonoBehaviour
{
    
    private UnityEngine.AI.NavMeshAgent _navMeshAgent;

    CarController _controller;
    public Waypoint waypoint;

    private void Awake() 
    {
        _controller = GetComponent<CarController>();
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Start() 
    {
        _navMeshAgent.SetDestination(waypoint.transform.position);
    }

    void Update()
    {
        if(!_navMeshAgent.pathPending && waypoint._nextWaypoint)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance) 
            {
                if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude == 0f) 
                {
                    waypoint = waypoint._nextWaypoint;
                    _navMeshAgent.SetDestination(waypoint.transform.position);
                }
            }
            
        }
       

    }
    
}
