using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;


public class CarAIController : MonoBehaviour
{
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

    public int carID=0;

    private CarStatus status;
    public AlgorithmType algorithm;

    public float stoppingDistance = 1f;
    public float reachedTargetDistance = 10f;
    private float sensorLenght =2f;

    public List<Waypoint> path=null;
    public Waypoint currentTarget=null;

    private CarController carController;

    public GameObject FrontSensor;

   
    void Awake ()
    {
        carController = gameObject.GetComponent<CarController>();
        status = CarStatus.Driving;
    
    }
    void Start()
    {
         //path = TrafficSystem.Instance.GetWaypoints();
    }

    void Update()
    {
        if(currentTarget==null)
            return;
        SensorUpdate();
        MoveCar();
        if(hasReachedTarget())
            SetNextTarget();
    }

    private void SetNextTarget()
    {
        currentTarget = WaypointNavigator.FindNextWaypoint(currentTarget);
    }

    private void SetAlgorithm()
    {
        switch (algorithm)
        {
            case AlgorithmType.Random:
                break;
            case AlgorithmType.Dijkstra:
                /*SetTargetPosition(
                    Dijkstra.FindShortestPath(trafficSystem.Duplicate())
                );*/
                break;
            default:
                break;
        }
    }

    private void MoveCar()
    {
        if(status == CarStatus.Stopped)
        {
            carController.StopCompletely();
            return;
        }
        //default values
        Vector2 movingValues = WaypointNavigator.GetAccelerationAndSteering(carController.GetPosition(),currentTarget.GetPosition(),reachedTargetDistance,carController.GetTransform());
        carController.SetInputs(movingValues[0],movingValues[1]);
        
    }

    private bool hasReachedTarget()
    {
        if (WaypointNavigator.CheckDistanceToPoint(carController.GetPosition(),currentTarget.GetPosition())<=5f)
            return true;
        return false;
    }


    public void SensorUpdate()
    {   
        RaycastHit[] hits;
        hits = Physics.RaycastAll(FrontSensor.transform.position,FrontSensor.transform.forward,sensorLenght);
        for(int i=0;i<hits.Length;i++)
        {
            
            if(hits[i].collider.tag =="Player"
                || hits[i].collider.tag =="Car")
            {
                Debug.Log(gameObject.name);
                status=CarStatus.Stopped;
                carController.StopCompletely();
            }
            if(hits[i].collider.tag=="TrafficLight")
            {
                Debug.Log("Lights");
                var lights= hits[i].collider.GetComponent<TrafficLight>();
                if(lights.IsRed())
                    status=CarStatus.Stopped;
                else if(!lights.IsRed() && status==CarStatus.Stopped)
                    status = CarStatus.Driving;
            }
            else
            {
                status = CarStatus.Driving;
            }

        }
    }
   
}
