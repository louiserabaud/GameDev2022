using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CarStatus
{
    Stopped,
    Driving
}

public enum AlgorithmType
{
    Random, 
    Dijkstra
}


public class CarAIController : MonoBehaviour
{
    public int carID;

    private CarStatus status;
    public AlgorithmType algorithm;

    public float stoppingDistance = 7f;

    public TrafficSystem trafficSystem = null;
    public List<Vector3> path;

    public GameObject car;
    private CarController carController;

    
    public Waypoint targetPosition;
   
    void Awake ()
    {
        carController = car.GetComponent<CarController>();
    
    }

    void Update()
    {
       Debug.Log(carController.GetSpeed());
        if(hasReachedTarget())
            SetNextTarget();
      
        MoveCar();
    }

    private void SetAlgorithm()
    {
        switch (algorithm)
        {
            case AlgorithmType.Random:
                break;
            case AlgorithmType.Dijkstra:
                SetTargetPosition(
                    Dijkstra.FindShortestPath(trafficSystem.Duplicate())
                );
                break;
            default:
                break;
        }
    }

    private void MoveCar()
    {
        //default values
        float forwardAmount = 1f;
        float turnAmount = 0f;

        float reachedTargetDistance = 10f;
        float distanceToTarget = CheckDistanteToTarget();
        //Debug.Log(distanceToTarget);

        if (distanceToTarget > reachedTargetDistance) {
            // Still too far, keep going
            turnAmount = GetAngleBetweenPosAndTarget(GetPosition(),targetPosition.GetPosition());
            //check if next node is a turn
        }
        if(CheckForTurn(targetPosition.GetPosition(),FindNextTarget().GetPosition()))
                
        {   
            Debug.Log("decrease");
            carController.SetAcceleration(-1f);
        }

        carController.SetInputs(forwardAmount, turnAmount);
        
    }

    private bool CheckForTurn(Vector3 target, Vector3 next)
    {
        var angle = GetAngleBetweenPosAndTarget(target,next);
        if(angle>0.3f || angle<-0.3f)
            return true;
        return false;
    }
    

    private float GetAngleBetweenPosAndTarget(Vector3 position, Vector3 target)
    {
        Vector3 dirToMovePosition = (target - position).normalized;
        float turnAmount = Mathf.Clamp(this.transform.InverseTransformDirection(dirToMovePosition).x, -1, 1);
        return turnAmount;
    }


    private bool hasReachedTarget()
    {
        if (CheckDistanteToTarget()<=5f)
        {
            return true;
        }
        return false;
    }

    private float CheckDistanteToTarget()
    {
        return Vector3.Distance(transform.position, targetPosition.GetPosition());
    }

    private void SetNextTarget()
    {
        targetPosition = targetPosition.next[0];
        Debug.Log("next target: " + targetPosition.GetPosition());
    }

    private Waypoint FindNextTarget()
    {
        return targetPosition.next[0];
    }

    private void SetTargetPosition(Waypoint target)
    {
        targetPosition = target;
    }
    
    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
