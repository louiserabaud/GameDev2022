using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DeliveryData
{
    public PickupLocation pickupLocation;
    public DeliveryLocation deliveryLocation;
    public DeliveryData(PickupLocation pickup,DeliveryLocation delivery)
    {
        pickupLocation = pickup;
        deliveryLocation = delivery;
    }
}
