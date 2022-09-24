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

    public TrafficSystem trafficSystem = null;
   
    void Start()
    {
        status=CarStatus.Stopped;
        algorithm=AlgorithmType.Random;

        if(trafficSystem==null)
            Debug.Log("Car id:"+carID +" has not been assigned to a traffic system");
    }

 
    void Update()
    {
        
    }
}
