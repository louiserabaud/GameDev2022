using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deliveryPoint : MonoBehaviour
{
    //initiate event in case delivered successfully
    public static System.Action OnCompleted;

    //this is the prefab that will appear in random loccations
    public GameObject locatePrefab;

    //variables to set the delivery parameters
    public float length;
    private float minX;
    private float maxX;
    private float minZ;
    private float maxZ;

    //minimum Distance to pickUpPoint
    public float minDist = 50.0f;


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

        //
        if (Vector3.Distance(deliveryPoint, gameObject.GetComponent<pickUpPoint>().transform.position) < minDist)
        {
            defineBuilding();
        }

    }

    public void OnTriggerEnter()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "deliver"))
        {
            if (OnCompleted != null)
            {
                OnCompleted?.Invoke();
            }
        }
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
