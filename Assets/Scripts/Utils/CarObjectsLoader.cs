using UnityEngine;
using System;
using System.Collections.Generic;

public static class CarObjectsLoader
{
    private static Dictionary<string,string> _CarsDict =
        new Dictionary<string,string>
        {
            {"Jeep5","Prefabs/CarObjects/Jeep5"}
        };
    private static string Jeep5 = "Prefabs/CarObjects/Jeep5";


    public static GameObject LoadModel(string model)
    {
        
        return Resources.Load<GameObject>(_CarsDict[model]);
    }
}