using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deliveryPoint : MonoBehaviour
{
    //this is the prefab that will appear in random loccations
    public GameObject locatePrefab;

    //variables to set the delivery parameters
    public float length;
    private float minX;
    private float maxX;
    private float minZ;
    private float maxZ;



    void Start()
    {
        deliverySystem.OnNewRound += defineBuilding;        //subscribed to OnNewRound
    }

    public void defineBuilding()
    {
        Debug.Log("Creating delivery location...");
        var houses = BuildingsController.Instance.getHouses();
        int index = Random.Range(0, houses.Count - 1);
        Vector3 deliveryPoint = houses[index].getPosition();
    }



    public void createDeliveryLocation()
    {
        Debug.Log("Creating delivery location");
        minX = transform.position.x - (length / 2);
        maxX = transform.position.x + (length / 2);
        minZ = transform.position.z - (length / 2);
        maxZ = transform.position.z + (length / 2);

        Vector3 deliveryPos = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
        //GameObject deliveryPoint = Instantiate(locatePrefab, deliveryPos, Quaternion.identity);


    }
}
