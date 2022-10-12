using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarSensors))]
public class Car : MonoBehaviour
{
      public enum State
    {
        Driving,
        Stop
    }

    public CarController _carController;

    public Node currentNode;
    public State _currentState;
    public Transform _frontSensor; 

    [Header("AI Settings")]
    public float maximumSpeed = 30.0f;
    public float _sensorLength=5.0f;
    public float maximumNodeDistance=7.0f;




    void Start()
    {
        _carController = PrefabManager.Instance.LoadCar(
            AssetDatabase.Cars.Get("Jeep5"),
            transform
        );
        _currentState = State.Driving;
        FindRootNode(0,20f);
        _frontSensor = transform.GetChild(0).Find("FrontSensor");
    }

    void Update()
    {
        UpdateSensors();
       
        //check if the destination is not null first
        if(currentNode==null)
            return;
        //check if the car is driving
        if(_currentState==State.Stop)
        {
            _carController.Brake(true);
            return;
        }
        // else we check for breaking and move the car
        float distance = Vector3.Distance(transform.position,currentNode.position);
        CheckForBraking();
        //ApplyTransforms();
        if(_currentState==State.Driving)
            MoveCar();
        if(WaypointNavigator.HasReachedDestination(transform.position,currentNode,maximumNodeDistance))
            currentNode = WaypointNavigator.GetNextTarget(currentNode);
    }

    
    private void MoveCar()
    {
        //find the steering and acceleration 
        float distance = Vector3.Distance(transform.position,currentNode.position);
        float acceleration = WaypointNavigator.GetAcceleration(transform.position,currentNode,transform);
        float steering = WaypointNavigator.GetSteering(transform.position,currentNode,transform);
        if(WaypointNavigator.CheckForTurn(transform.position,currentNode,transform) && distance<5.0f)
            acceleration=-1.0f;
        _carController.SetAcceleration(acceleration);
        _carController.SetSteering(steering);
    }

      private bool CheckForBraking()
        {
            if(_currentState == State.Stop)
            {
                _carController.Brake(true);
                return true;
            }
             _carController.Brake(false);
            return false;
        }



    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.Log(collision.gameObject.name);
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }

    /*public void UpdateSensors()
    {
        //______
        // ref: https://youtu.be/PiYffouHvuk
        //_____
        RaycastHit hit;
        Vector3 sensorStartPosition = transform.position;
        sensorStartPosition+=transform.forward*frontSensorPosition.z;
        sensorStartPosition += transform.up * frontSensorPosition.y;


    }*/

     public void FindRootNode(float degrees, float distance)
      {
        //find the next waypoint in front
        //of the car object when it's instantiated 
        if(currentNode!=null)
            return;
        RaycastHit[] hits;
            // local coordinate rotation around the Y axis to the given angle
            Quaternion rotation = Quaternion.AngleAxis(degrees, Vector3.up);        
            // add the desired distance to the direction
            Vector3 addDistanceToDirection = rotation * transform.forward * distance;
            // add the distance and direction to the current position to get the final destination
            var destination = transform.position + addDistanceToDirection;
            Debug.DrawRay(transform.position, addDistanceToDirection, Color.red, 10.0f);
            transform.LookAt(destination);
            
            hits = Physics.RaycastAll(transform.position, transform.forward, 100.0f);
            for (int i = 0; i < hits.Length; i++)
        {
            if(hits[i].collider.tag=="Waypoint")
            {
                
                Waypoint waypoint = hits[i].collider.gameObject.GetComponent<Waypoint>();
                currentNode = Graph.GetNodeFromWaypoint(waypoint,TrafficSystem.Instance.GetWaypoints());
            }
        }
     }

     public void UpdateSensors()
    {   
        RaycastHit[] hits;
        hits = Physics.RaycastAll(_frontSensor.transform.position,_frontSensor.transform.forward,_sensorLength);
        if(hits.Length==0)
        {
            _currentState=State.Driving;
            return;
        }
        for(int i=0;i<hits.Length;i++)
        {
            Debug.Log(hits[i].collider.tag);
            if(hits[i].collider.tag =="Player"
                || hits[i].collider.tag =="Car")
            {
                _currentState=State.Stop;
                return;
            }
            else if(hits[i].collider.tag=="TrafficLight")
            {
                var lights= hits[i].collider.GetComponent<TrafficLight>();
                if(lights.IsRed())
                {
                    _currentState=State.Stop;
                    return;
                }
                else if(!lights.IsRed() && _currentState==State.Stop)
                    _currentState = State.Driving;
            }
            else
            {
                _currentState = State.Driving;
            }
        }
    }
}