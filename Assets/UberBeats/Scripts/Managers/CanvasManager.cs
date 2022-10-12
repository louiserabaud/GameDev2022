using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CanvasType
{
    Empty,
    MainMenu,
    DrivingScreen,
    BeforePickupScreen,
    PickupScreen,
    DeliveryRequest,
    WinScreen,
    LooseScreen,
    EndScreen
}


public class CanvasManager : Singleton<CanvasManager>
{
    List<CanvasController> canvasControllerList;
    CanvasController lastActiveCanvas;

    protected override void Awake()
    {
        Debug.Log("Entered canvas manager");
        base.Awake();
        canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
        Debug.Log(canvasControllerList.Count);
        canvasControllerList.ForEach(x => x.gameObject.SetActive(false));
        SwitchCanvas(CanvasType.Empty);
        ListenToEvents();
    }

    private void ListenToEvents()
    {
        EventManager.StartListening(
            "OnNewDeliveryRequest",
            SetNewDeliveryRequest);
        EventManager.StartListening(
            "OnPlayerPickUp",
            OnPlayerPickupDelivery);
    }

    public void SwitchCanvas(CanvasType _type)
    {
        if (lastActiveCanvas != null)
        {
            lastActiveCanvas.gameObject.SetActive(false);
        }

        CanvasController desiredCanvas = canvasControllerList.Find(x => x.canvasType == _type);
        if (desiredCanvas != null)
        {
            desiredCanvas.gameObject.SetActive(true);
            lastActiveCanvas = desiredCanvas;
        }
        else { 
            Debug.LogWarning("The desired canvas was not found! : " + _type); }
    }

    public void SetNewDeliveryRequest()
    {
        SwitchCanvas(CanvasType.DeliveryRequest);
    }

    public void OnPlayerPickupDelivery()
    {
        SwitchCanvas(CanvasType.PickupScreen);
    }
 }
