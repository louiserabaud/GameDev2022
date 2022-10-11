using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Competitor : MonoBehaviour
{

    public Car _car;
    [SerializeField] private PickupLocation pickUpLocation;
    [SerializeField] private DeliveryLocation deliveryLocation;



    public void StartChase(PickupLocation start, DeliveryLocation end)
    {
        pickUpLocation = start;
        deliveryLocation = end;
        ApplyTransform(pickUpLocation.GetTransform());
        InitCarObject(pickUpLocation.GetClosestWaypoint());
    }

    private void InitCarObject(Waypoint waypoint,GameObject model=null)
    {
        Debug.Log("init car");
        if(model==null)
            {
                GameObject car = new GameObject("Car",typeof(Car));
                car.transform.SetParent(transform,false);
                car.tag="Competitor";
                _car = car.GetComponent<Car>();
            }
        
        _car.GetAIController().SetCurrentTarget(FindShortestPath());
    }

    private Node FindShortestPath()
    {
        return AI.AlgorithmManager.FindShortestPath(
            AI.Algorithm.AStar,
            pickUpLocation.GetClosestWaypoint(),
            deliveryLocation.GetClosestWaypoint(),
            TrafficSystem.Instance.GetWaypoints()
            );
    }

    private void ApplyTransform(Transform _transform)
    {
        transform.position = _transform.position;
        transform.rotation = _transform.rotation;
    }

    private void Update()
    {
        if(_car==null || pickUpLocation==null || deliveryLocation==null)
            return;
        ApplyTransform(_car.transform);
        
    }



}