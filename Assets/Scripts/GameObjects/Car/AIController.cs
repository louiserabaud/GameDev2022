using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public enum Status
    {
        Driving,
        Stop
    }

    [SerializeField] private CarController _carController=null;
    //[SerializeField] private SensorControler _sensorController;

    [SerializeField] private Status _status = Status.Driving;
    
   
    [SerializeField] private Node  _currentTarget=null;

    [SerializeField] private float maxTargetDistance=7.0f;
    [SerializeField] private float minTargetDistance=7.0f;


    [SerializeField] private Transform _frontSensor;
    [SerializeField] private float _sensorLength=5f;


    
    void Start()
    {
       if(_currentTarget==null)
            FindAnchorWaypoint(0,20);
        if(_carController==null)
            _carController = gameObject.GetComponent<CarController>();
        if(_frontSensor==null)
            _frontSensor = gameObject.transform.Find("FrontSensor");
         _carController.SetAccelerationAndSteering(1.0f,0.0f);
    }

    public void SetCurrentWaypoint(Waypoint currentposition)
    {
        _currentTarget = Graph.GetNodeFromWaypoint(currentposition,TrafficSystem.Instance.GetWaypoints());
    }

    public void SetCurrentTarget(Node start)
    {
        _currentTarget = start;
    }




    void Update()
    {
       // Debug.Log(_currentTarget.position);
         UpdateSensors();

        if(_carController==null || _currentTarget==null)
            return;
        if(_status==Status.Stop)
        {
            _carController.Brake(true);
            return;
        }
       
        float distance = Vector3.Distance(transform.position,_currentTarget.position);
        CheckForBraking();
        //ApplyTransforms();
        if(_status==Status.Driving)
            MoveCar();
        if(WaypointNavigator.HasReachedDestination(transform.position,_currentTarget,maxTargetDistance))
            _currentTarget = WaypointNavigator.GetNextTarget(_currentTarget);
        
    }


    void ApplyTransforms()
    {
        transform.position = _carController.GetTransform().position;
    }


    void MoveCar()
    {
        //default values
        float distance = Vector3.Distance(transform.position,_currentTarget.position);
        float acceleration = WaypointNavigator.GetAcceleration(transform.position,_currentTarget,transform);
        float steering = WaypointNavigator.GetSteering(transform.position,_currentTarget,transform);
        if(WaypointNavigator.CheckForTurn(transform.position,_currentTarget,transform) && distance<5.0f)
            acceleration=-1.0f;
        
        _carController.SetAccelerationAndSteering(acceleration,steering);
    }


    bool CheckForBraking()
    {
        if(_status == Status.Stop)
        {
            _carController.Brake(true);
            return true;
        }
        return false;
    }

    public Transform GetTransform()
    {
        return transform;
    }


    public void FindAnchorWaypoint(float degrees, float distance)
      {
        if(_currentTarget!=null)
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
                    _currentTarget = Graph.GetNodeFromWaypoint(waypoint,TrafficSystem.Instance.GetWaypoints());
                }

            }
     }






     public void UpdateSensors()
    {   
        RaycastHit[] hits;
        hits = Physics.RaycastAll(_frontSensor.transform.position,_frontSensor.transform.forward,_sensorLength);
        if(hits.Length==0)
        {
            _status=Status.Driving;
            return;
        }

        for(int i=0;i<hits.Length;i++)
        {
            
            if(hits[i].collider.tag =="Player"
                || hits[i].collider.tag =="Car")
            {
                _status=Status.Stop;
                return;
            }
            else if(hits[i].collider.tag=="TrafficLight")
            {
                var lights= hits[i].collider.GetComponent<TrafficLight>();
                if(lights.IsRed())
                    _status=Status.Stop;
                else if(!lights.IsRed() && _status==Status.Stop)
                    _status = Status.Driving;
            }
            else
            {
                _status = Status.Driving;
            }

        }
    }
}