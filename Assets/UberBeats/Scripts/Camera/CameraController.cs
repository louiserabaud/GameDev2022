using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target = null;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;


    
    private void Awake(){
        translateSpeed = 10;
        rotationSpeed=12;
        offset = new Vector3(0f,1.6f,-8.0f);
        
    }

    private void Start() 
    {
        
    }
    void SetCameraTarget()
    {
        
    }

    private void SetOffset(float x, float y, float z)
    {
        offset = new Vector3(x,y,z);
    }

    public void SetCameraTarget(Transform _target)
    {
        target = _target;
    }

    private void FixedUpdate()
    {
        if(target==null)
            return;
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


