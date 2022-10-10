using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Competitor : MonoBehaviour
{

    private GameObject carObject;

    public void InitCarObject(Transform transform,GameObject model=null)
    {
        if(model==null)
            {
                string modelPath = AssetDatabase.Cars.GetRandom();
                carObject = Instantiate(Resources.Load(modelPath) as GameObject,transform);  
            }
            
        carObject.AddComponent<AIController>();
        gameObject.tag="Car";
    }

}