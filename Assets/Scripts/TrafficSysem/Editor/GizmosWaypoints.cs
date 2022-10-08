using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class GizmosWaypoints 
{

    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void OnDrawSceneGizmo(Waypoint waypoint, GizmoType gizmoType)
    {
        Color color = Color.blue;
        if(waypoint.GetTag() == "CarWaypoint")
            {
                Gizmos.color = Color.red;
                color = Color.blue;
            }
        else
            Gizmos.color = Color.blue;
        Gizmos.DrawSphere(waypoint.GetPosition(),0.5f);
        DrawArrow.ForGizmo(waypoint.GetPosition(),waypoint.GetTransform().forward*6.0f,Color.red,2f);

        if(waypoint.next.Count>=1)
        {
            foreach(var nextpoint in waypoint.next)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(waypoint.transform.position, nextpoint.transform.position);
                var p1 = waypoint.transform.position;
                var p2 = nextpoint.transform.position;
                var thickness = 1;
                /*#if UNITY_EDITOR //Check if running a build or in editor
                    Handles.DrawBezier(p1,p2,p1,p2, Color.green,null,thickness);
                #endif*/
                
            }
        }
    }

}
