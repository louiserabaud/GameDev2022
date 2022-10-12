using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Competitor : Car
{
    [SerializeField] private PickupLocation pickUpLocation;
    [SerializeField] private DeliveryLocation deliveryLocation;
    public void SetDeliveryData(PickupLocation start, DeliveryLocation end)
    {
        gameObject.tag="Competitor";
        gameObject.name="Competitor";
        pickUpLocation = start;
        deliveryLocation = end;
        ApplyTransform(pickUpLocation.GetTransform());
    }

    private void ApplyTransform(Transform _transform)
    {
        transform.position = _transform.position;
        transform.rotation = _transform.rotation;
    }

}