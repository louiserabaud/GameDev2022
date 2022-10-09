using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace AssetDatabase
{
    public static class Cars
    {
        private static Dictionary<string,string> _CarsDict =
            new Dictionary<string,string>
            {
                {"Jeep5","Prefabs/CarObjects/Jeep5"}
            };

        public static string Get(string model)
        {
            return _CarsDict[model];
        }

        public static string GetRandom( )
        {   string random= GetElementAtIndex(Random.Range(0,_CarsDict.Count));
            return random;
        }

        public static string GetElementAtIndex(int randIndex)
        {
            int index = 0;
            foreach(var model in _CarsDict)
            {
                if(index==randIndex)
                    return model.Value;
                index++;
            }

            return null;
        }
    }
}
