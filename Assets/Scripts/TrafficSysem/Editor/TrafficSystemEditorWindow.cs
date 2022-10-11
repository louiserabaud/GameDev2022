using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System;


public class TrafficSystemEditorWindow : EditorWindow

   
  {
    [MenuItem("Tools/UberBeats/Traffic System Editor")]
    public static void Open()
    {
        GetWindow<TrafficSystemEditorWindow>();
    }
    
    public Transform TrafficSystem;
    public int waypointCount=0;
    public int intersectionCount=0;

    private void OnGUI() 
    {
        SerializedObject obj = new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("TrafficSystem"));
        if(TrafficSystem==null)
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
        
        if(Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<Waypoint>())
        {
             if(GUILayout.Button("Extrude Waypoint"))
            {
                ExtrudeWaypoint();
            }

             if(GUILayout.Button("Create Waypoint after"))
            {
                AddWaypointAfter();
            }
             if(GUILayout.Button("Remove Waypoint"))
            {
               // RemoveWaypoint();
            }
        }
        else
        {
            if(GUILayout.Button("Create Waypoint"))
            {
                CreateWaypoint();
            }
            if(GUILayout.Button("Add Car Position"))
            {
                AddRandomCar();
            }
            if(GUILayout.Button("Set Player Position"))
            {
               AddPlayerPosition();
            }
        }
    }


    void EditRoadWaypoints()
    {
        if(Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<Waypoint>())
        {
             if(GUILayout.Button("Extrude Waypoint"))
            {
                ExtrudeWaypoint();
            }

             if(GUILayout.Button("Create Waypoint after"))
            {
                AddWaypointAfter();
            }
             if(GUILayout.Button("Remove Waypoint"))
            {
               // RemoveWaypoint();
            }
        }
        else
        {
            if(GUILayout.Button("Create Waypoint"))
            {
                CreateWaypoint();
            }
        }
    }

    void EditCarPositionsWaypoints()
    {
         if(GUILayout.Button("Add Car Position"))
            {
                AddRandomCar();
            }
    }

    void EditPlayerPositionsWaypoints()
    {
         if(GUILayout.Button("Set Player Position"))
            {
               AddPlayerPosition();
            }
    }

    
    void CreateWaypoint()
    {
        GameObject waypointObject = new GameObject("Waypoint" + waypointCount,typeof(Waypoint));
        Selection.activeGameObject = waypointObject;
        waypointObject.transform.SetParent(TrafficSystem.transform.Find("Waypoints"),false);
        Selection.activeGameObject = waypointObject;
        waypointObject.tag="Waypoint";
        waypointObject.AddComponent<SphereCollider>();
        var collider = waypointObject.GetComponent<SphereCollider>();
        collider.radius = 2.7f;
        collider.isTrigger=true;
        waypointCount++;
    }

     void CreateCar()
    {
        GameObject carObject = new GameObject("Car" + waypointCount,typeof(Car));
        Selection.activeGameObject = carObject;
        carObject.transform.SetParent(TrafficSystem.transform.Find("Cars"),false);
        Selection.activeGameObject = carObject;
        carObject.tag="Car";
    }

    void ExtrudeWaypoint()
    {
        Waypoint parent = Selection.activeGameObject.GetComponent<Waypoint>();
        CreateWaypoint();
        Waypoint waypoint = Selection.activeGameObject.GetComponent<Waypoint>();
        waypoint.parent = parent;
        waypoint.SetTransform(parent.GetTransform());
        waypoint.SetPosition(parent.GetTransform().position*1.05f);
        parent.next.Add(waypoint);

    }

    void AddWaypointAfter()
    {
        Waypoint parent = Selection.activeGameObject.GetComponent<Waypoint>();
        CreateWaypoint();
        Waypoint waypoint = Selection.activeGameObject.GetComponent<Waypoint>();
        waypoint.parent = parent;
        waypoint.SetPosition(parent.GetTransform().position);
        foreach(var child in parent.next)
            {
                child.parent = waypoint;
                waypoint.next.Add(child);
            }
        parent.next.Clear();
        parent.next.Add(waypoint);
    }

  
     void CreateIntersection()
    {
        var trafficLights = new List<TrafficLight>();
        var locations = new Vector3[4]
        {
            new Vector3(3,0,-5),
            new Vector3(-5,0,-3),
            new Vector3(-3,0,5),
            new Vector3(5,0,3)
        };
        var intersection = new GameObject("Intersection " + intersectionCount,typeof(Intersection));
        intersection.transform.SetParent(TrafficSystem.GetChild(1),false);
        intersection.gameObject.tag = "Intersection";
        intersection.gameObject.transform.position = new Vector3(0,0,0);
        for(int i=0;i<4;i++)
        {
            var lights = CreateTrafficLight(intersection,locations[i]);
        } 
        intersectionCount++;
    }

     TrafficLight CreateTrafficLight(GameObject intersection,Vector3 position)
    {
        GameObject obj = (GameObject)Resources.Load("TrafficLight");
        var lights = Instantiate(obj,position,intersection.transform.rotation);
        lights.gameObject.transform.position = new Vector3(0,0,0);
        lights.transform.SetParent(intersection.gameObject.transform,false);
        lights.name="TrafficLight";
        lights.tag="TrafficLight";
        return lights.GetComponent<TrafficLight>();
    }

    void AddRandomCar()
    {
        CreateCar();
        var carObj = Selection.activeGameObject;
        var carWaypoint = carObj.GetComponent<Car>();
        carObj.transform.SetParent(TrafficSystem.transform.Find("Cars"),false);
        carWaypoint.tag="Car";
        carWaypoint.name="Car";

    }


    void  AddPlayerPosition()
    {
        CreateWaypoint();
        var carObj = Selection.activeGameObject;
        var carWaypoint = carObj.GetComponent<Waypoint>();
        carObj.transform.SetParent(TrafficSystem.transform,false);
        carWaypoint.tag="PlayerWaypoint";
        carWaypoint.name="PlayerWaypoint";
    }
   
    
}