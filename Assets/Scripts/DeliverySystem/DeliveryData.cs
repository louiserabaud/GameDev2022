using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeliveryData : MonoBehaviour
{
    private int i = 0;
    private int e = 3;

    

    private void Awake()
    {
        deliveryPlace.printDeliveryDataText += PrintText;
    }

    private void OnEnable()
    {
        PrintText();
    }

    private void OnDisable()
    {
        deliveryPlace.printDeliveryDataText -= PrintText;
    }

    public void PrintText()
    {
        Debug.Log("You got an order by " + randomName() + ". Get it from " + pickUpLocation() + " ! Quick, get it to " + " !");
    }

    public string randomName() //could also be sequential; people would not notice
    {
        string[] names = {
            "LarryLobster",
            "BobbyThePenguin",
            "MichelleObama",
            "SteveWonderfulWorld",
            "WonderGirl",
            "FoodAddict23",
            "Diegito",
            "InPizzaITrust",
            "EatASnickers!",
            "EdwardsInTown",
            "PhoPhoPho"
        };
        if (i == names.Length)
        {
            i = 0;
        }
        else
        {
            i++;
        }
        string name = names[i];
        return name;
    }


    public string pickUpLocation()
    {
        string[] locations =
        {
            "at the juction",
            "by the library",
            "somewhere near",
            "at the crossroad",
            "daminos",
            "donutsrat",
            "DT"
        };
        if (e == 0)
        {
            e = locations.Length;
        }
        else
        {
            e--;
        }
        string location = locations[e];
        return location;
    }
}
