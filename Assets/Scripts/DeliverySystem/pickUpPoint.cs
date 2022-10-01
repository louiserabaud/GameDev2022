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


    void Start()
    {
        deliverySystem.OnNewRound += defineBuilding;      //subscribed to OnNewRound
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
            //save state variable
        }
    }
    /*
    public void createPickUpLocation()
    {
        Debug.Log("Creating pickUp location...");


        minX = transform.position.x - (length / 2);
        maxX = transform.position.x + (length / 2);
        minZ = transform.position.z - (length / 2);
        maxZ = transform.position.z + (length / 2);

        Vector3 pickUpPos = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
        GameObject pickUpPoint = Instantiate(locatePrefab, pickUpPos, Quaternion.identity);
        
    }*/




    /*

    private void Awake()
    {
        //sound to make the player aware of the start of the mission
        //_audioSource = GetComponent<AudioSource>();
    }*/


}
