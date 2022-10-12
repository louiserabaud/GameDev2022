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
        SwitchLights(groupId1);
        InvokeRepeating("UpdateGroupLight", lightsDuration, lightsDuration);
    }

    void SwitchLights(List<TrafficLight> group)
    {
        foreach(var light in group)
        {
            light.SwitchColor();
        }
        //let only one light green for traffic flow
        
    }

    void UpdateGroupLight()
    {
        SwitchLights(groupId1);
        SwitchLights(groupId2);
    }


    
}
