using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrafficLight : MonoBehaviour
{
    public static event Action CrossedRedLight;


    

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
        }
    }

    public bool IsRed()
    {
        if(color == LightColor.Red)
            return true;
        return false;
    }

    void OnTriggerEnter(Collider otherObject){
        if(otherObject.GetComponent<Collider>().tag=="Player")
            CrossedRedLight?.Invoke();
    }
  



}
