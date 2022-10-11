using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DeliverySystem : MonoBehaviour
{
    public static System.Action OnDeliveryRequest;

    public static DeliverySystem Instance { get; private set; }
    [SerializeField] private List<DeliveryLocation> _deliveryLocations= new List<DeliveryLocation>();
    [SerializeField] private List<PickupLocation> _pickupLocations=new List<PickupLocation>();

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

    public void Start()
    {
        GatherGameObjects();
    }

    public void RequestNewDelivery()
    {
        if(isRunning==true || _deliveryLocations.Count<1 || _pickupLocations.Count<1)
            return;
        
        var random_pickUp = _pickupLocations[Random.Range(0,(_pickupLocations.Count)-1)];
        var random_delivery = _deliveryLocations[Random.Range(0,(_deliveryLocations.Count)-1)];
        OnDeliveryRequest?.Invoke();
    }

    private void GatherGameObjects()
    {
        foreach(Transform position in transform.Find("PickupLocations").transform)
            {
                _pickupLocations.Add(position.GetComponent<PickupLocation>());
            }
        foreach(Transform position in transform.Find("DeliveryLocations").transform)
            {
                _deliveryLocations.Add(position.GetComponent<DeliveryLocation>());
            }
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