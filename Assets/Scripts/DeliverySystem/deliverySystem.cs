using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deliverySystem : MonoBehaviour
{
    //tell the game a new event is being set up
    public static System.Action OnNewRound;


    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log("Invoke new event");
        OnNewRound?.Invoke();               //invoke new event
        //Delay(1000);
        //System.WaitForSeconds(2);
    }
}
