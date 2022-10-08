using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCar : MonoBehaviour
{
    [SerializeField] private CarController _carController;
    //[SerializeField] private SensorControler _sensorController;

    [SerializeField] private Transform _startingPosition; 
    [SerializeField] private Waypoint _currentTarget;

    public RandomCar(GameObject carObject,Transform startPos, Waypoint target)
    {
        transform.tag="Car";
        transform.name="Car";
        _startingPosition = startPos;
        _currentTarget = target;
        /** Car  is instantiated once we have a car object starting pos and waypoint target **/
        if(_startingPosition!=null && _currentTarget!=null && carObject!=null)
        {
            var carObj = Instantiate(carObject,startPos);
            _carController = carObj.GetComponent<CarController>();
        }

    }
}