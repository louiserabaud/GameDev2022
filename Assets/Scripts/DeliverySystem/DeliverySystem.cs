using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeliverySystem : MonoBehaviour
{
    
    public static DeliverySystem Instance { get; private set; }
    [SerializeField] private List<DeliveryLocation> _deliveryLocations=null;
    [SerializeField] private List<PickupLocation> _pickupLocations=null;

    [SerializeField] private bool isRunning = false;

    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }  
    }

    public void InitiateNewDelivery()
    {
        if(isRunning==true)
            return;
    }

    private void SetDeliveryLocations(List<DeliveryLocation> _locations)
    {
        _deliveryLocations = _locations;
    }

    private void SetDeliveryLocations(List<PickupLocation> _locations)
    {
        _pickupLocations = _locations;
    }

}