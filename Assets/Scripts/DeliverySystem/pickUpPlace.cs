using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpPlace : MonoBehaviour
{
    public GameObject locatePrefab; //character that will appear insert here; where to take it too

    public float length;

    public int minDist = 20; //minDist needs to be tested

    private float minX;
    private float maxX;
    private float minZ;
    private float maxZ;

    //public static System.Action doDeliveryPlace;

    private void Start()
    {
        deliverySystem.current.OnNewRound += createPickUpLocation;
    }

    /*private void Awake()
    {
        Debug.Log("I have reached pickUpPlace");
        Testloader.testRun += createPickUpLocation;
        EventManager.OnClicked += createPickUpLocation;
        
    }*/

    private void OnEnable()
    {
        createPickUpLocation();
        Debug.Log("arrived at pickUp");
        //fire createDeliveryLocation();
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("deliveryPrefab").transform.position) < minDist)
        {
            Debug.Log("Theyre were too close");
            createPickUpLocation();
            //Problem: location will appear anywhere; we need it within a building -> List of them
            //if person within building make her transparent
        }
    }

    private void OnDisable()
    {
        Testloader.testRun -= createPickUpLocation;
        EventManager.OnClicked -= createPickUpLocation;
    }

    public void createPickUpLocation()
    {
        Debug.Log("Creating pickUp location...");
        minX = transform.position.x - (length / 2);
        maxX = transform.position.x + (length / 2);
        minZ = transform.position.z - (length / 2);
        maxZ = transform.position.z + (length / 2);

        Vector3 pickUpPos = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
        GameObject pickUpPoint = Instantiate(locatePrefab, pickUpPos, Quaternion.identity);

        //doDeliveryPlace?.Invoke();
    }
}
