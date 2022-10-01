using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deliverySystem : MonoBehaviour
{
    //tell the game a new event is being set up
    public static System.Action OnNewRound;    

    void Start()
    {
        deliveryPoint.OnCompleted += nextRound;
    }

    //void Update()
    public void nextRound()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        Debug.Log("Wait a bit before the next event");
        //wait between 5 and 60 seconds before next round
        int counter = Random.Range(5, 61);
        yield return new WaitForSeconds(counter);
        Debug.Log("Invoke new event");
        OnNewRound?.Invoke();               //invoke new event every time the round is done
    }

}
