using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpPoint : MonoBehaviour
{
    //this is the prefab that will appear in random loccations
    public GameObject locatePrefab;

    //variables to set the delivery parameters
    public float length;
    private float minX;
    private float maxX;
    private float minZ;
    private float maxZ;

    public bool pickedUp;

    void Start()
    {
        deliverySystem.OnNewRound += defineBuilding;      //subscribed to OnNewRound
        pickedUp = false;
    }

    public void defineBuilding()
    {
        Debug.Log("Creating pickUp location...");
        var buisiness = BuildingsController.Instance.getBuisnesses();
        int index = Random.Range(0, buisiness.Count-1);
        Vector3 pickUpPoint = buisiness[index].getPosition();
    }

    public void OnTriggerEnter()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "pick-up order"))
        {
            pickedUp = true;
        }
    }

    public bool getPickedUp()
    {
        return pickedUp;
    }
}
