using UnityEngine;
using System;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    private CarController _carController;

    private void Awake()
    {
        gameObject.name="Player";
        gameObject.tag="Player";
        LoadCar();
    }

    private void LoadCar()
    {
        var carObj = Instantiate(CarObjectsLoader.LoadModel("Jeep5"),transform.parent);
        carObj.transform.parent = transform;
        _carController = carObj.GetComponent<CarController>();

    }

    private void Update()
    {
        //get user inputs:
        float acceleration = Input.GetAxis("Horizontal");
        float steering = Input.GetAxis("Vertical");
        bool breaking = Input.GetKey(KeyCode.Space);
        _carController.SetBrake(breaking);
        _carController.SetAccelerationAndSteering(acceleration,steering);
    }

    public Transform GetCameraTarget()
    {
        return  _carController.GetCameraTarget();
    }

   
}