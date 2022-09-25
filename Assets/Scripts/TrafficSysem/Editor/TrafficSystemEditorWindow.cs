using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class TrafficSystemEditorWindow : EditorWindow
{
    public TrafficSystem trafficSystem;
    private float yoffset = 0.0f;

    public static int nIntersection =0;

    [MenuItem("Window/TafficSystem Editor")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        TrafficSystemEditorWindow window = (TrafficSystemEditorWindow)EditorWindow.GetWindow(typeof(TrafficSystemEditorWindow));
        window.Show();
    }

    void OnGUI() 
    {
        DrawUILine(Color.clear);
        SerializedObject obj = new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("trafficSystem"));
        if (trafficSystem==null)
        {
            EditorGUILayout.HelpBox("Please assign a traffic system",MessageType.Warning);
        }
        else
        {
            DrawUILine(Color.gray);
            DrawButtons();
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
        }
        else
        {
            if(GUILayout.Button("Create a Waypoint"))
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
        var waypoint = new GameObject("Waypoint " + GetCount(),typeof(Waypoint));
        waypoint.transform.SetParent(trafficSystem.gameObject.transform,false);
        waypoint.gameObject.tag="Waypoint";
        Selection.activeGameObject = waypoint.gameObject;
    }

    TrafficLight CreateTrafficLight(GameObject intersection,Vector3 position)
    {
        GameObject obj = (GameObject)Resources.Load("TrafficLight");
        var lights = Instantiate(obj,position,intersection.transform.rotation);
        lights.gameObject.transform.position = new Vector3(0,0,0);
        lights.transform.SetParent(intersection.gameObject.transform,false);
        return lights.GetComponent<TrafficLight>();
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
        var intersection = new GameObject("Intersection " + nIntersection,typeof(Intersection));
        intersection.gameObject.tag = "Intersection";
        intersection.gameObject.transform.position = new Vector3(0,0,0);
        for(int i=0;i<4;i++)
        {
            var lights = CreateTrafficLight(intersection,locations[i]);
        }
        
        
    }

    void ExtrudeWaypoint()
    {
        var parent = Selection.activeGameObject.GetComponent<Waypoint>();
        var waypoint = new GameObject("Waypoint " + GetCount(),typeof(Waypoint));
        waypoint.gameObject.tag="Waypoint";
        waypoint.transform.SetParent(trafficSystem.gameObject.transform,false);
        Waypoint newWaypoint = waypoint.GetComponent<Waypoint>();

        newWaypoint.parent = parent;
        parent.next.Add(newWaypoint);
        waypoint.transform.position = parent.transform.position;
        waypoint.transform.forward = parent.transform.forward;
        Selection.activeGameObject = waypoint.gameObject;



    }

    public static void DrawUILine(Color color, int thickness = 1, int padding = 20)
    {
        Rect r = EditorGUILayout.GetControlRect(GUILayout.Height(padding+thickness));
        r.height = thickness;
        r.y+=padding/2;
        r.x-=2;
        r.width +=6;
        EditorGUI.DrawRect(r, color);
    }

    public  int GetCount()
    {
        return trafficSystem.gameObject.transform.childCount;
    }


    
}
