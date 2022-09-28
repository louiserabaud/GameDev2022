using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CarFactory 
{
    static int ids=0;
    public static int GetCarID()
    {
        ids++;
        return ids;
    }
}
