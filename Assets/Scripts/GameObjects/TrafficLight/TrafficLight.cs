using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrafficLight : MonoBehaviour
{
    public static event Action CrossedRedLight;
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

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider otherObject){
        if(color==LightColor.Red && otherObject.GetComponent<Collider>().gameObject.tag=="player")
        {
            Debug.Log("Player crossed a red light");
            CrossedRedLight?.Invoke();
        }
    }
  



}
