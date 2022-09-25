using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Intersection : MonoBehaviour
{
    public List<TrafficLight> groupId1;
    public List<TrafficLight> groupId2;

    public float lightsDuration = 8;

    void Start()
    {
        //UpdateGoup(groupId1);
        InvokeRepeating("SwitchLights", lightsDuration, lightsDuration);
    }

    void SwitchLights()
    {
        foreach(var light in groupId1)
        {
            light.SwitchColor();
        }
    }

    
}
