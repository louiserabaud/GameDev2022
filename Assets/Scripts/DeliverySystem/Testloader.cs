using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testloader : MonoBehaviour
{
    public delegate void test();
    public static event test testRun;

    //public static System.Action testRun;

    void OnAwake()
    {
        
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "Click"))
        {
            if (testRun != null)
                testRun();
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Q was pressed");
            testRun?.Invoke();
            //OnNewRound?.Invoke();
        }
    }

    void OnDisable()
    {

    }
}
