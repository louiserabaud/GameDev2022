using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    void OnTriggerEnter(Collider otherObject){
         if(otherObject.gameObject.name=="Player"){
            Debug.Log("Player crossed red light");
            otherObject.GetComponent<PlayerController>().CrossedRedLight();
        }
    }
}
