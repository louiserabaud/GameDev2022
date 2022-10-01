using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsController : MonoBehaviour
{
    public List<Building> buildings;
    public List<Building> businesses;
    public List<Building> houses;

    public static BuildingsController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
     }


    void Start()
    {
        buildings = new List<Building>();
        foreach(Transform child in transform)
        {
            Building building = child.GetComponent<Building>();
            buildings.Add(building);
            if (building.construction == Building.Construction.buisness)
            {
                businesses.Add(building);
            }
            else if (building.construction == Building.Construction.house)
            {
                houses.Add(building);
            }
        }
    }

    public List<Building> getBuisnesses()
    {
        return businesses;
    }

    public List<Building> getHouses()
    {
        return houses;
    }
}
