using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deliveryPlace : MonoBehaviour
{
    public GameObject deliveryPrefab;

    //Variables for randomLocation
    public float length;
    public int minDist = 20; //minDist needs to be tested
    private float minX;
    private float maxX;
    private float minZ;
    private float maxZ;

    public static System.Action printDeliveryDataText;

    private void Awake()
    {
        pickUpPlace.doDeliveryPlace += createDeliveryLocation;
    }

    private void OnEnable() //=> DeliveryData.PrintText += createDeliveryLocation;
    {
        
    }

    private void OnDisable()
    {

    }

    private void createDeliveryLocation()
    {
        Debug.Log("Creating delivery location...");
        minX = transform.position.x - (length / 2);
        maxX = transform.position.x + (length / 2);
        minZ = transform.position.z - (length / 2);
        maxZ = transform.position.z + (length / 2);

        Vector3 deliveryPos = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
        GameObject pickUpPoint = Instantiate(deliveryPrefab, deliveryPos, Quaternion.identity);

        printDeliveryDataText?.Invoke();
    }
}
