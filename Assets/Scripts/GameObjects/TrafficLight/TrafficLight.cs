using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrafficLight : MonoBehaviour
{
    public static event Action<String> CrossedRedLight;
    public static event Action OnGreenLight;

    

    public enum LightColor
    {
        Green,
        Red
    }
    public enum Axis
    {
        vertical,
        horizontal
    }

    public LightColor color;
    private Axis axis;

    public Light pointLight;

  
    void Awake()
    {
        UpdateColor();
    }

    public void SwitchColor()
    {
        if(color==LightColor.Green)
            color=LightColor.Red;
        else
            color=LightColor.Green;
        UpdateColor();
    }

    public void UpdateColor()
    {
        if(color == LightColor.Red)
        {
            pointLight.color = new Color(1, 0, 0);
        }
        else
        {
            pointLight.color = new Color(0, 1, 0);
            OnGreenLight?.Invoke();
        }
    }

    public bool IsRed()
    {
        if(color == LightColor.Red)
            return true;
        return false;
    }

    void OnTriggerEnter(Collider otherObjectCollider){
        var otherObject = otherObjectCollider.GetComponent<Collider>().gameObject;
        
    }
  



}
