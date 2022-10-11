using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public GameObject carObject;
    private void Awake()
    {
        InitCarObject(transform);
    }
    public void InitCarObject(Transform transform,GameObject model=null)
    {
        if(carObject!=null)
            return;
        if(model==null)
            {
                string modelPath = AssetDatabase.Cars.GetRandom();
                carObject = Instantiate(Resources.Load(modelPath) as GameObject,transform);
                carObject.transform.parent=transform;  
            }
        carObject.AddComponent<AIController>();
        gameObject.tag="Car";
    }

    public void SetTag(string tag)
    {
        gameObject.tag = tag;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

     public Transform GetTransform()
    {
        return transform;
    }

    public AIController GetAIController()
    {
        return carObject.GetComponent<AIController>();
    }

}
