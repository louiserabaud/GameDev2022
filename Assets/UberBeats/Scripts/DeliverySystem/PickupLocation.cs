using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickupLocation : MonoBehaviour
{
    public static Action OnPickup;
    [SerializeField] private Waypoint _waypoint;


    public bool isWaitingForPickup=false;

    private void Start()
    {
        EventManager.StartListening("OnAcceptDelivery",SetDataForPickup);
    }

    public void SetTransform(Transform _transform)
    {
        transform.position = _transform.position;
        transform.rotation = _transform.rotation;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public Waypoint GetClosestWaypoint()
    {
        return _waypoint;
    }

    private void SetDataForPickup()
    {
        isWaitingForPickup=true;
    }

    void OnTriggerEnter(Collider otherObject){
        if(otherObject.GetComponent<Collider>().tag=="Player" && isWaitingForPickup)
            {
                EventManager.TriggerEvent("OnPlayerPickUp");
                isWaitingForPickup=false;
            }
            
    }

    void OnCollisionExit(Collision otherObject){
        if(otherObject.collider.GetComponent<Collider>().tag=="Player")
            EventManager.TriggerEvent("OnCompetitionStarted");
    }
}