using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDev.Car
{

    public enum Color
    {
        red
    }

    public enum Brand
    {
        none 
    }

    public class Data : ScriptableObject
    {
        Brand _currentBrand;
        Color _currentColor;
    }

}
