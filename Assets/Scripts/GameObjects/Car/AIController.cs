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
    [SerializeField] private CompetitorController _competitorController;

    [SerializeField] private Status _status = Status.Driving;
   
    [SerializeField] private Waypoint _currentTarget=null;
    [SerializeField] private float maxTargetDistance=15f;

    void Start()
    {
       if(_currentTarget==null)
            FindAnchorWaypoint(0,20);
        if(_carController==null)
            _carController = gameObject.GetComponent<CarController>();
         _carController.SetAccelerationAndSteering(1.0f,0.0f);
    }



    void Update()
    {
        if(_carController==null || _currentTarget==null)
            return;
        CheckForBraking();
        //ApplyTransforms();
        if(WaypointNavigator.HasReachedDestination(transform.position,_currentTarget,maxTargetDistance))
            _currentTarget = WaypointNavigator.GetNextWaypoint(_currentTarget);
        if(_status==Status.Driving)
            MoveCar();
    }

    void ApplyTransforms()
    {
        transform.position = _carController.GetTransform().position;
    }

    void MoveCar()
    {
        //default values
        float acceleration = 1.0f;
        float steering = 0.0f;
        float distance = Vector3.Distance(transform.position,_currentTarget.GetPosition());
        Debug.Log(distance);
        if(distance<= maxTargetDistance)
        {
            acceleration = WaypointNavigator.GetAcceleration(transform.position,_currentTarget,transform);
        }
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
            Debug.Log("find anchor");
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
                    _currentTarget = hits[i].collider.gameObject.GetComponent<Waypoint>();
            }
     }
}