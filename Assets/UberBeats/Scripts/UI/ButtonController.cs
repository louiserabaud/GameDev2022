using UnityEngine;
using UnityEngine.UI;

public enum ButtonType
{
    ACCEPT_DELIVERY,
    DECLINE_DELIVERY
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
            case ButtonType.DECLINE_DELIVERY:
                Debug.Log("decline");
                //Call other code that is necessary to start the game like levelManager.StartGame()
                canvasManager.SwitchCanvas(CanvasType.DrivingScreen);
                break;
            case ButtonType.ACCEPT_DELIVERY:
                Debug.Log("accepty");
                //Do More Things like SaveSystem.Save()
                canvasManager.SwitchCanvas(CanvasType.DrivingScreen);
                break;
            default:
                break;
        }
    }
}


