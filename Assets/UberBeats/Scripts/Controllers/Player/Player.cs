using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CarController _carController;
    public Transform cameraTarget=null;

    void Start()
    {
        _carController = PrefabManager.Instance.LoadCar(
            AssetDatabase.Cars.Get("Jeep5"),
            transform,
            "Player"
        );
        cameraTarget = transform.GetChild(0).Find("CameraTarget");
        transform.parent=null;
        SetMainCameraTarget();
    }

    private void SetMainCameraTarget()
    {
        GameObject.FindWithTag("MainCamera").GetComponent<Camera>().GetComponent<CameraController>().SetCameraTarget(cameraTarget);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}