using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class TrafficSystemEditorWindow : EditorWindow
{
    public TrafficSystem trafficSystem;
    private float yoffset = 0.0f;

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
        }
    }

    void CreateWaypoint()
    {
        var waypoint = new GameObject("Waypoint " + trafficSystem.gameObject.transform.childCount,typeof(Waypoint));
        waypoint.transform.SetParent(trafficSystem.gameObject.transform,false);
        Selection.activeGameObject = waypoint.gameObject;
    }

    void ExtrudeWaypoint()
    {
        var parent = Selection.activeGameObject.GetComponent<Waypoint>();
        var waypoint = new GameObject("Waypoint " + trafficSystem.gameObject.transform.childCount,typeof(Waypoint));
        waypoint.transform.SetParent(trafficSystem.gameObject.transform,false);
        Waypoint newWaypoint = waypoint.GetComponent<Waypoint>();

        newWaypoint.parent = parent;
        parent.next.Add(newWaypoint);
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



    
}
