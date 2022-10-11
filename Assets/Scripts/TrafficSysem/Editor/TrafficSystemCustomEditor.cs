using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;


public class AssetHandler
{
    [OnOpenAsset()]
    public static bool OpenEditor(int instanceId, int line)
    {
        TrafficSystem obj = EditorUtility.InstanceIDToObject(instanceId) as TrafficSystem;
        if (obj!=null)
        {
            TrafficSystem2EditorWindow.Open(obj);
        }
        return false;
    }
}

[CustomEditor(typeof(TrafficSystem))]
public class TrafficSystemCustomEditor: Editor
{
    public override void OnInspectorGUI()
    {
        if(GUILayout.Button("Open Editor"))
        {
            TrafficSystem2EditorWindow.Open((TrafficSystem)target);
        }
    }
}