using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public CarController _carController;

    void Awake()
    {
        _carController = PrefabManager.Instance.LoadCar(
            AssetDatabase.Cars.Get("Jeep5"),
            transform
        );
    }


    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}