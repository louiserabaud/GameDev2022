using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Intersection : MonoBehaviour
{
    public List<TrafficLight> groupId1;
    public List<TrafficLight> groupId2;


    void Start()
    {
        UpdateGoup(groupId1);
    }

    void UpdateGoup(List<TrafficLight> groupId1)
    {
        foreach(var light in groupId1)
        {
            light.SwitchColor();
        }
    }

    
}
