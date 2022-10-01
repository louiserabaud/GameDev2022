using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deliverySystem : MonoBehaviour
{
    public static deliverySystem current;
    public static System.Action OnNewRound;

    private void Awake()
    {
        //current = this;
    }

    void Update()
    {
        OnNewRound?.Invoke();
        System.Delay(1000);
    }
    //public event System.Action OnNewRound;


    public void newRound()
    {
        //listen for roundDone event
        OnNewRound?.Invoke();
    }

    public void OnTriggerEnter()
    {
        Debug.Log("Q was pressed");
        OnNewRound?.Invoke();
    }
}
