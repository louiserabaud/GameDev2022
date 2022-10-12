using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PrefabManager : MonoBehaviour
{
    public static PrefabManager Instance { get; private set; }

    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public CarController LoadCar(string path, Transform _parent, string tag="Car")
    {
        GameObject car = Instantiate(Resources.Load(path) as GameObject,_parent);
        car.transform.parent = _parent;
        car.tag=tag;
        return car.GetComponent<CarController>();
    }
}