using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ge : MonoBehaviour
{
    //event initiate in case player lost
    public static System.Action OnDead;

    //this is the prefab that will appear in random loccations
    public GameObject locatePrefab;

    //radius in which delivery is possible
    public int radiuss = 23;

    //obj to call get setCollider in Building script
    public Building building;

    void Start()
    {
        deliverySystem.OnNewRound += defineBuilding;        //subscribed to OnNewRound
    }

    public void defineBuilding()
    {
        Debug.Log("Creating fake delivery location...");
        var houses = BuildingsController.Instance.getHouses();
        int index = Random.Range(0, houses.Count - 1);
        Vector3 deliveryPoint = houses[index].getPosition();
    }

    public void OnTriggerEnter()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "deliver"))
        {
            if (OnDead != null)
            {
                OnDead?.Invoke();
            }
        }
    }
}
