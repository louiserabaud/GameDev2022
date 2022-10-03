using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System;


public class TrafficSystemEditorWindow : EditorWindow

   
  {
    [MenuItem("Tools/Waypoint Editor")]
    public static void Open()
    {
        GetWindow<TrafficSystemEditorWindow>();
    }
    
    public Transform trafficSystem;
    public int waypointCount=0;
    public int intersectionCount=0;

    private void OnGUI() 
    {
        SerializedObject obj = new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("trafficSystem"));
        if(trafficSystem==null)
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
             if(GUILayout.Button("Create Waypoint after"))
            {
                AddWaypointAfter();
            }
             if(GUILayout.Button("Remove Waypoint"))
            {
               // RemoveWaypoint();
            }
            if (GUILayout.Button("Add a new branch"))
            {
               AddBranch();
            }

             if (GUILayout.Button("Merge two Points"))
            {
                MergePoints();
            }
            
        }else
        {
            if(GUILayout.Button("Create Waypoint"))
            {
                CreateWaypoint();
            }
             if(GUILayout.Button("Create an Intersection"))
            {
                CreateIntersection();
            }
        }
    }

    
    void CreateWaypoint()
    {
        GameObject waypointObject = new GameObject("Waypoint" + waypointCount,typeof(Waypoint));
        waypointObject.transform.SetParent(trafficSystem.GetChild(0),false);
        Selection.activeGameObject = waypointObject;
        waypointCount++;
    }

    void AddWaypointAfter()
    {
        Waypoint parent = Selection.activeGameObject.GetComponent<Waypoint>();
        CreateWaypoint();
        Waypoint waypoint = Selection.activeGameObject.GetComponent<Waypoint>();
        waypoint.parent = parent;
        waypoint.SetPosition(parent.GetPosition() + new Vector3(1,0,1));
        if(parent.next.Count>0)
            {
                waypoint.next = parent.next;
                parent.next.Clear();
            }
        parent.next.Add(waypoint);
    }

    void MergePoints()
    {
        if(!(Selection.transforms.Length!=2 && Selection.transforms[0].tag=="Waypoint" && Selection.transforms[1].tag=="Waypoint"))
            {
                Debug.Log("not enough or too many obj selected");
                return;
            }
        Waypoint parentPoint = Selection.transforms[0].GetComponent<Waypoint>();
        Waypoint childPoint = Selection.transforms[1].GetComponent<Waypoint>();

        parentPoint.next.Add(childPoint);
        childPoint.parent = parentPoint;
    }

    void AddBranch()
    {
        Waypoint parent = Selection.activeGameObject.GetComponent<Waypoint>();
        CreateWaypoint();
        Waypoint waypoint = Selection.activeGameObject.GetComponent<Waypoint>();
        waypoint.parent = parent;
        parent.next.Add(waypoint);
        waypoint.SetPosition(parent.GetPosition()+ new Vector3(1,0,1));
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
        intersection.transform.SetParent(trafficSystem.GetChild(1),false);
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

   
    
}