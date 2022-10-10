using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public enum Construction
    {
        buisiness,
        house
    }
    [SerializeField] private Construction _construction;

    
}