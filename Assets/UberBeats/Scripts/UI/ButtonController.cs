using UnityEngine;
using UnityEngine.UI;

public enum ButtonType
{
    PLAY_BUTTON,
    ACCEPT_DELIVERY,
    DECLINE_DELIVERY,
    PICKUP_DELIVERY
}

[RequireComponent(typeof(Button))]
public class ButtonController : MonoBehaviour
{
    public ButtonType buttonType;

    CanvasManager canvasManager;
    Button menuButton;
    
    private void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OnButtonClicked);
        canvasManager = CanvasManager.GetInstance();
    }

    void OnButtonClicked()
    {
        switch (buttonType)
        {
            case ButtonType.PLAY_BUTTON:
                //Call other code that is necessary to start the game like levelManager.StartGame()
                canvasManager.SwitchCanvas(CanvasType.DrivingScreen);
                break;
            case ButtonType.DECLINE_DELIVERY:
                //Call other code that is necessary to start the game like levelManager.StartGame()
                EventManager.TriggerEvent("OnDeclineDelivery");
                canvasManager.SwitchCanvas(CanvasType.DrivingScreen);
                break;
            case ButtonType.ACCEPT_DELIVERY:
                //Do More Things like SaveSystem.Save()
                EventManager.TriggerEvent("OnAcceptDelivery");
                canvasManager.SwitchCanvas(CanvasType.DrivingScreen);
                break;
            case ButtonType.PICKUP_DELIVERY:
                canvasManager.SwitchCanvas(CanvasType.DrivingScreen);
                break;
            default:
                break;
        }
    }
}


