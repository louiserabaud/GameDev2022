using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System;


public class DeliverySystemEditorWindow : EditorWindow
{
    [MenuItem("Tools/UberBeats/Delivery System Editor")]
    public static void Open()
    {
        GetWindow<DeliverySystemEditorWindow>();
    }

    public Transform deliverySystem;

     private void OnGUI() 
    {
        SerializedObject obj = new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("deliverySystem"));
        if(deliverySystem==null)
        {
            EditorGUILayout.HelpBox("Root transform must be selected.Please assign a root transform.",MessageType.Warning);
        }else{
            EditorGUILayout.BeginVertical("box");
            DrawButtons();
            EditorGUILayout.EndVertical();
        }
        obj.ApplyModifiedProperties();
    }

    void DrawButtons()
    {
        if(Selection.activeGameObject != null )
        {
            if(GUILayout.Button("Add Pickup Location"))
            {
                AddPickupLocation();
            }
            if(GUILayout.Button("Add Delivery Location"))
            {
                AddDeliveryLocation();
            }
        }
    }

    void AddPickupLocation()
    {
        var location = Selection.activeGameObject;
        GameObject pickupObj = new GameObject("PickupLocation",typeof(PickupLocation));
        pickupObj.transform.position = location.transform.position;
        pickupObj.transform.SetParent(deliverySystem.transform.Find("PickupLocations"),false);
        Selection.activeGameObject = pickupObj;
        //set tag of object
        pickupObj.tag="PickupLocation";

        //add collider
        pickupObj.AddComponent<BoxCollider>();
        var collider = pickupObj.GetComponent<BoxCollider>();
        collider.size = new Vector3(8.0f,4.0f,5.5f);
        collider.isTrigger=true;
    }

    void AddDeliveryLocation()
    {
        var location = Selection.activeGameObject;
        GameObject deliveryObj = new GameObject("DeliveryLocation",typeof(DeliveryLocation));
        deliveryObj.transform.position = location.transform.position;
        deliveryObj.transform.SetParent(deliverySystem.transform.Find("DeliveryLocations"),false);
        Selection.activeGameObject = deliveryObj;
        //set tag of object
        deliveryObj.tag="DeliveryLocation";

        //add collider
        deliveryObj.AddComponent<BoxCollider>();
        var collider = deliveryObj.GetComponent<BoxCollider>();
        collider.size = new Vector3(8.0f,4.0f,5.5f);
        collider.isTrigger=true;
    }


}