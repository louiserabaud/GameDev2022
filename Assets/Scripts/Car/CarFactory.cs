using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameDev.Car;

namespace GameDev 
{
    public class CarFactory : MonoBehaviour
    {
        public static GameObject CreateCar(Data carData, Vector3 position)
        {
            return Instantiate(carData,position,Quaternion.identity);
        }
    }
}