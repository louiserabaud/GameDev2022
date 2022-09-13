using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaypointManagerWindow : EditorWindow

{
    [MenuItem("Tools/Waypoint Editor")]
    public static void Open()
    {
        GetWindow<WaypointManagerWindow>();
    }
    public Transform waypointRoot;

    private void OnGUI() 
    {
        SerializedObject obj = new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("waypointRoot"));
        if(waypointRoot==null)
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
        if(GUILayout.Button("Create Waypoint"))
        {
            CreateWaypoint();
        }
        if(Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<Waypoint>())
        {
            if(GUILayout.Button("Create Waypoint before"))
            {
                CreateWaypointBefore();
            }
             if(GUILayout.Button("Create Waypoint after"))
            {
                CreateWaypointAfter();
            }
             if(GUILayout.Button("Remove Waypoint"))
            {
                RemoveWaypoint();
            }
            
        }
    }

    void CreateWaypointBefore()
    {
        GameObject waypointObject = new GameObject("waypoint" + waypointRoot.childCount,typeof(Waypoint));
        waypointObject.transform.SetParent(waypointRoot,false);

        Waypoint newWaypoint = waypointObject.GetComponent<Waypoint>();
        Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();
        waypointObject.transform.position = selectedWaypoint.transform.position;
        waypointObject.transform.forward = selectedWaypoint.transform.forward;
        if(selectedWaypoint._previousWaypoint !=null){
            newWaypoint._previousWaypoint = selectedWaypoint._previousWaypoint;
            selectedWaypoint._previousWaypoint._nextWaypoint = newWaypoint;

        }
        newWaypoint._nextWaypoint = selectedWaypoint;
        selectedWaypoint._previousWaypoint = newWaypoint;

        newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());
        Selection.activeGameObject = newWaypoint.gameObject;
    }

    void CreateWaypointAfter()
    {
        GameObject waypointObject = new GameObject("waypoint" + waypointRoot.childCount,typeof(Waypoint));
        waypointObject.transform.SetParent(waypointRoot,false);

        Waypoint newWaypoint = waypointObject.GetComponent<Waypoint>();
        Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();
        waypointObject.transform.position = selectedWaypoint.transform.position;
        waypointObject.transform.forward = selectedWaypoint.transform.forward;
        if(selectedWaypoint._previousWaypoint !=null)
        {
            selectedWaypoint._nextWaypoint._previousWaypoint = newWaypoint;
            newWaypoint._nextWaypoint = selectedWaypoint._nextWaypoint;

        }
        selectedWaypoint._nextWaypoint = newWaypoint;
        newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());
        Selection.activeGameObject = newWaypoint.gameObject;
    }

    void RemoveWaypoint()
    {
        Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();
        if(selectedWaypoint._nextWaypoint !=null)
        {
            selectedWaypoint._nextWaypoint._previousWaypoint = selectedWaypoint._previousWaypoint;
        }
        if(selectedWaypoint._previousWaypoint !=null)
        {
            selectedWaypoint._previousWaypoint._nextWaypoint = selectedWaypoint._nextWaypoint;
            Selection.activeGameObject = selectedWaypoint._previousWaypoint.gameObject;
        }
        DestroyImmediate(selectedWaypoint.gameObject);
    }

    void CreateWaypoint()
    {
        GameObject waypointObject = new GameObject("waypoint" + waypointRoot.childCount,typeof(Waypoint));
        waypointObject.transform.SetParent(waypointRoot,false);

        Waypoint waypoint = waypointObject.GetComponent<Waypoint>();
        if(waypointRoot.childCount>1)
        {
            waypoint._previousWaypoint = waypointRoot.GetChild(waypointRoot.childCount-2).GetComponent<Waypoint>();
            waypoint._previousWaypoint._nextWaypoint = waypoint;
            waypoint.transform.position = waypoint._previousWaypoint.transform.position;
            waypoint.transform.forward = waypoint._previousWaypoint.transform.forward;
       }
       Selection.activeGameObject = waypoint.gameObject;

    }
    
}
