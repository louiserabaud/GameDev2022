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
        var p1 = deliveryLocation.GetClosestWaypoints()[0];
        var p2 = deliveryLocation.GetClosestWaypoints()[1];

        var root1 = FindShortestPath(p1);
        var root2 = FindShortestPath(p2);
        Debug.Log(GetPathDistance(root1));
        Debug.Log(GetPathDistance(root2));

        Debug.Log("init car");
        if(model==null)
            {
                GameObject car = new GameObject("Car",typeof(Car));
                car.transform.SetParent(transform,false);
                car.tag="Competitor";
                _car = car.GetComponent<Car>();
            }
        
        
        _car.GetAIController().SetCurrentTarget(root1);
    }

    private float GetPathDistance(Node root)
    {
        float distance = 0.0f;
        Node currentNode = root;
        while(currentNode.next.Count>0)
        {
            distance+=Vector3.Distance(currentNode.position,currentNode.next[0].position);
            currentNode = currentNode.next[0];
        }
        return distance;
    }

    private Node FindShortestPath(Waypoint p)
    {
        return AI.AlgorithmManager.FindShortestPath(
            AI.Algorithm.AStar,
            pickUpLocation.GetClosestWaypoint(),
            p,
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