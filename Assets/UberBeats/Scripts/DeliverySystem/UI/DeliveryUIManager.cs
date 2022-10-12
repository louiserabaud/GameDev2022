using UnityEngine;
using System;
using System.Collections.Generic;

public class DeliveryUIManager : MonoBehaviour
{

    void Awake()
    {
        DeliverySystem.OnDeliveryRequest+=LoadNewDeliveryRequestWindow;
    }

    void LoadNewDeliveryRequestWindow(DeliveryData data)
    {
        Debug.Log("delivery Generated");
        DeliverySystem.OnAcceptDelivery?.Invoke(data);
    }
}