using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CompetitorStateManager))]
public class CompetitorController : MonoBehaviour
{
    public GameObject _Car;

    void Awake(){
        // instantiate the car here
    }
}
