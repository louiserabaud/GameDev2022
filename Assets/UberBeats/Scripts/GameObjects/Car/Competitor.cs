using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Competitor : MonoBehaviour
{

    private GameObject carObject;
    [SerializeField] private Waypoint pickUpLocation;
    [SerializeField] private Waypoint deliveryLocation;

    public void StartChase(Waypoint start, Waypoint end)
    {
        pickUpLocation = start;
        deliveryLocation = end;
        InitCarObject(start.GetTransform());
    }

    private void InitCarObject(Transform transform,GameObject model=null)
    {
        if(model==null)
            {
                string modelPath = AssetDatabase.Cars.GetRandom();
                carObject = Instantiate(Resources.Load(modelPath) as GameObject,transform);  
            }
            
        carObject.AddComponent<AIController>();
        gameObject.tag="Car";
    }

    private void Update()
    {
        if(carObject==null || pickUpLocation==null || deliveryLocation==null)
            return;
    }



}