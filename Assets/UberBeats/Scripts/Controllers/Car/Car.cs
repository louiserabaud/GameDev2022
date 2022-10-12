using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarSensors))]
public class Car : MonoBehaviour
{
    public CarController _carController;
    public CarSensors _sensors;
    public Node currentNode;

    [Header("AI Settings")]
    public float maximumSpeed = 16;

    void Start()
    {
        _carController = PrefabManager.Instance.LoadCar(
            AssetDatabase.Cars.Get("Jeep5"),
            transform
        );
        _sensors = GetComponent<CarSensors>();
    }

    public void FindRootNode()
    {
        //find the next waypoint in front
        //of the car object when it's instantiated 
    }

    public void FindSensors()
    {

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
}