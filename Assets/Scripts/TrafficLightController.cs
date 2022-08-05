using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrafficLightController : MonoBehaviour
{
    public static event Action CrossedRedLight;

    void Start(){
        Debug.Log("Traffic Light");
    }

    void OnTriggerEnter(Collider otherObject){
         if(otherObject.gameObject.name=="Player"){
            Debug.Log("Player crossed red light");
            CrossedRedLight?.Invoke();
        }
    }
}
