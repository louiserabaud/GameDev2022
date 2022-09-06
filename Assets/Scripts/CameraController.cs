using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    public static  GameObject player;
    public Transform target;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;


    public static GameObject GetPlayerObject(){
        return player;
    }

    
    private void Awake(){
        target = GameObject.Find("Player").transform;
        translateSpeed = 10;
        rotationSpeed=12;
       offset.x = 0;
       offset.y = 2;
        offset.z = -5;
  
    
    }

    private void Start(){
        //target = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }
   
    private void HandleTranslation()
    {
        var targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
    }
    private void HandleRotation()
    {
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}

